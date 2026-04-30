using FireSharp;
using FireSharp.Config;
using FireSharp.Interfaces;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System.Collections;
using System.IO.Compression;
using System.Reflection;
using System.Text;

namespace FirebaseApp
{
    public partial class Form1 : Form
    {
        private JObject migratedRoot;
        IFirebaseConfig config = new FirebaseConfig
        {
            AuthSecret = "5CaaG8Clt7gxWY37stzqHFGvuAim5A7IsVrqQXux", // Replace with your Firebase auth secret,
            BasePath = "https://bbslate-7adce-default-rtdb.firebaseio.com/" ,// Replace with your Firebase database URL
            RequestTimeout = TimeSpan.FromMinutes(50) // 🔥 increase a lot
        };
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            IFirebaseClient firebaseClient = new FireSharp.FirebaseClient(config);
            if (firebaseClient != null)
            {
                MessageBox.Show("Firebase client initialized successfully.");

            }
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private async void button1_Click(object sender, EventArgs e)
        {
            System.Net.ServicePointManager.SecurityProtocol = System.Net.SecurityProtocolType.Tls12;
            IFirebaseClient firebaseClient = new FireSharp.FirebaseClient(config);

            string collectionName = textBox1.Text;

            var response = await firebaseClient.GetAsync($"{collectionName}/PageInfo");

            if (response.Body == "null")
                return;

            treeView1.Nodes.Clear();

            var json = JToken.Parse(response.Body);

            TreeNode rootNode = new TreeNode("PageInfo");

            AddJsonToTree(json, rootNode);

            treeView1.Nodes.Add(rootNode);
            treeView1.ExpandAll();
        }
        private void AddJsonToTree(JToken token, TreeNode parent)
        {
            if (token is JObject obj)
            {
                foreach (var property in obj.Properties())
                {
                    TreeNode node = new TreeNode(property.Name);
                    parent.Nodes.Add(node);

                    AddJsonToTree(property.Value, node);
                }
            }
            else if (token is JArray array)
            {
                for (int i = 0; i < array.Count; i++)
                {
                    TreeNode node = new TreeNode($"[{i}]");
                    parent.Nodes.Add(node);

                    AddJsonToTree(array[i], node);
                }
            }
            else
            {
                // Primitive value
                parent.Text += $" : {token}";
            }
        }
        private static string ConvertToDeltaString(List<StrokePoint2> points)
        {
            if (points == null || points.Count == 0)
                return string.Empty;

            StringBuilder sb = new StringBuilder();

            double lastX = 0;
            double lastY = 0;

            for (int i = 0; i < points.Count; i++)
            {
                var p = points[i];

                if (i == 0)
                {
                    sb.Append($"{p.x},{p.y},{p.force}");
                    lastX = p.x;
                    lastY = p.y;
                }
                else
                {
                    double dx = p.x - lastX;
                    double dy = p.y - lastY;

                    sb.Append($":{dx},{dy},{p.force}");

                    lastX = p.x;
                    lastY = p.y;
                }
            }

            return sb.ToString();
        }
        private async void button2_Click(object sender, EventArgs e)
        {
            System.Net.ServicePointManager.SecurityProtocol = System.Net.SecurityProtocolType.Tls12;
            IFirebaseClient firebaseClient = new FireSharp.FirebaseClient(config);

            string collectionName = textBox1.Text;

            var response = await firebaseClient.GetAsync($"{collectionName}/PageInfo");
            // var response = await firebaseClient.GetAsync(basePath);

            if (response.Body == "null")
            {
                MessageBox.Show("No data found.");
                return;
            }

            JObject rootJson = JObject.Parse(response.Body);

            // This will hold migrated structure for treeView2
            //JObject migratedRoot = new JObject();
             migratedRoot = new JObject();

            foreach (var level1 in rootJson.Properties()) // 166503
            {
                JObject level1Obj = new JObject();

                foreach (var level2 in level1.Value.Children<JProperty>()) // 10355
                {
                    JObject level2Obj = new JObject();

                    foreach (var level3 in level2.Value.Children<JProperty>()) // 28253
                    {
                        string key1 = level1.Name;
                        string key2 = level2.Name;
                        string key3 = level3.Name;

                        var drawObject = level3.Value.ToObject<DrawInfoFirebase>();

                        if (drawObject == null)
                            continue;

                        // 🔹 Compress
                        string compressed = CompressDrawData(drawObject);

                        // 🔹 Save back to Firebase (replace only level3)
                        //await firebaseClient.SetAsync(
                        //    $"{basePath}/{key1}/{key2}/{key3}",
                        //    new { DrawInfo = compressed });

                        // 🔹 Build migrated JSON for TreeView2
                        level2Obj[key3] = new JObject
                        {
                            ["DrawInfo"] = compressed
                        };
                    }

                    level1Obj[level2.Name] = level2Obj;
                }

                migratedRoot[level1.Name] = level1Obj;
            }

            // 🔥 Show in treeView2
            treeView2.Nodes.Clear();

            TreeNode rootNode = new TreeNode("LiveSessionInfo");
            AddJsonToTree(migratedRoot, rootNode);

            treeView2.Nodes.Add(rootNode);
            treeView2.ExpandAll();

            MessageBox.Show("Migration Completed ✅");
        }
        public static string CompressDrawData(DrawInfoFirebase model)
        {
            // 🔥 Convert to iOS exact structure first
            var iosFormatted = ConvertToFirebaseFormat(model);

            var json = System.Text.Json.JsonSerializer.Serialize(iosFormatted);
            var jsonBytes = Encoding.UTF8.GetBytes(json);

            using var output = new MemoryStream();
            using (var zlib = new ZLibStream(output, CompressionLevel.Optimal, true))
            {
                zlib.Write(jsonBytes, 0, jsonBytes.Length);
            }

            return Convert.ToBase64String(output.ToArray());
        }
        private static DrawInfo ConvertToFirebaseFormat(DrawInfoFirebase original)
        {
            var convertedStrokeList = new List<StrokeDataCompressed>();
            if(original.strokeData != null)
            {
                foreach (var stroke in original.strokeData)
                {
                    string deltaString = ConvertToDeltaString(stroke.strokePoints);

                    convertedStrokeList.Add(new StrokeDataCompressed
                    {
                        strokeInkType = stroke.strokeInkType,
                        strokeColor = stroke.strokeColor,
                        strokeWidth = stroke.strokeWidth,
                        alpha = stroke.alpha,
                        strokePoints = deltaString
                    });
                }
            }
        

            return new DrawInfo
            {
                timestamp = original.timestamp,
                strokeData = convertedStrokeList
            };
        }

        private async void button3_Click(object sender, EventArgs e)
        {
            if (migratedRoot == null || !migratedRoot.HasValues)
            {
                MessageBox.Show("Please migrate data first.");
                return;
            }

            IFirebaseClient firebaseClient = new FireSharp.FirebaseClient(config);

            try
            {
                string uploadPath = "Production_DB/LiveSessionInfo";

                await firebaseClient.SetAsync(uploadPath, migratedRoot);

                MessageBox.Show("Upload Completed ✅");
            }
            catch (Exception ex)
            {
                MessageBox.Show("Upload failed: " + ex.Message);
            }
        }
    }
}
