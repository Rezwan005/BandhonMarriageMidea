using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FirebaseApp
{
    public class DrawInfoFirebase
    {
        public string _id { get; set; }
        public int pageId { get; set; }
        public string pageURL { get; set; }
        public List<StrokeDatum> strokeData { get; set; }
        public string timestamp { get; set; }
        public int userId { get; set; }
    }

    public class StrokeDatum
    {
        public double alpha { get; set; }
        public string strokeColor { get; set; }
        public string strokeInkType { get; set; }
        public List<StrokePoint2> strokePoints { get; set; }
        public double strokeWidth { get; set; }
        public string timestamp { get; set; }
    }

    public class StrokePoint2
    {
        public double altitude { get; set; }
        public double azimuth { get; set; }
        public int force { get; set; }
        public double opacity { get; set; }
        public string timestamp { get; set; }
        public double x { get; set; }
        public double y { get; set; }
    }

    public class StrokeDataCompressed
    {
        public string strokeInkType { get; set; }
        public string strokeColor { get; set; }
        public double strokeWidth { get; set; }
        public double alpha { get; set; }
        public string strokePoints { get; set; }   // delta string
    }

    public class DrawInfo
    {
        public string timestamp { get; set; }

        public List<StrokeDataCompressed> strokeData { get; set; }
    }


}
