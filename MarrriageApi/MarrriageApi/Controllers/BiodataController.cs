using Marriage.Core.Entity;
using Marriage.Infrastructure.Data;
using MarrriageApi.Dtos;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Security.Claims;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace MarrriageApi.Controllers
{
    public class BiodataController : ControllerBase
    {
        private readonly ApplicationDbContext _context;
        private readonly IWebHostEnvironment _env;
        public BiodataController(ApplicationDbContext context, IWebHostEnvironment env)
        {
            _context = context;
            _env = env;
        }   

        [HttpPost("general-info")]
        public async Task<IActionResult> SaveGeneralInfo([FromBody] BiodataGeneralInfoDto dto)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            // Check if biodata already exists for the user
            var existingEntity = await _context.BiodataGeneralInfos
                .FirstOrDefaultAsync(x => x.UserId == dto.UserId);

            if (existingEntity != null)
            {
                // Update existing record
                existingEntity.BiodataType = dto.BiodataType;
                existingEntity.MaritalStatus = dto.MaritalStatus;
                existingEntity.BirthDate = dto.BirthDate;
                existingEntity.Height = dto.Height;
                existingEntity.SkinTone = dto.SkinTone;
                existingEntity.Age = dto.Age;
                existingEntity.Weight = dto.Weight;
                existingEntity.BloodGroup = dto.BloodGroup;
                existingEntity.Nationality = dto.Nationality;

                _context.BiodataGeneralInfos.Update(existingEntity);
                await _context.SaveChangesAsync();

                return Ok(new
                {
                    message = "General information updated successfully",
                    id = existingEntity.Id
                });
            }
            else
            {
                // Create new record
                var entity = new BiodataGeneralInfo
                {
                    UserId = dto.UserId,
                    BiodataType = dto.BiodataType,
                    MaritalStatus = dto.MaritalStatus,
                    BirthDate = dto.BirthDate,
                    Height = dto.Height,
                    SkinTone = dto.SkinTone,
                    Weight = dto.Weight,
                    BloodGroup = dto.BloodGroup,
                    Nationality = dto.Nationality
                };

                _context.BiodataGeneralInfos.Add(entity);
                await _context.SaveChangesAsync();
                await CompleteStep(1);
                return Ok(new
                {
                    message = "General information saved successfully",
                    id = entity.Id
                });
            }
        }

        [Authorize]
        [HttpGet("general-info/{userId}")]
        public async Task<IActionResult> GetGeneralInfoByUserId(int userId)
        {
            var data = await _context.BiodataGeneralInfos
                .Where(x => x.UserId == userId)
                .Select(x => new
                {
                    x.Id,
                    x.UserId,
                    x.BiodataType,
                    x.MaritalStatus,
                    x.BirthDate,
                    x.Height,
                    x.Age,
                    x.SkinTone,
                    x.Weight,
                    x.BloodGroup,
                    x.Nationality
                })
                .FirstOrDefaultAsync();

            if (data == null)
                return NotFound(new { message = "General information not found" });

            return Ok(data);
        }

        [HttpPost("save")]
        public async Task<IActionResult> SaveAddress([FromBody] AddressDto dto)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var existing = await _context.UserAddresses
                .FirstOrDefaultAsync(x => x.UserId == dto.UserId);

            if (existing != null)
            {
                // UPDATE existing
                existing.PermanentCountry = dto.PermanentCountry;
                existing.PermanentDivision = dto.PermanentDivision;
                existing.PermanentDivisionId = dto.PermanentDivisionId;
                existing.PermanentDistrict = dto.PermanentDistrict;
                existing.PermanentDistrictId = dto.PermanentDistrictId;
                existing.PermanentUpazila = dto.PermanentUpazila;
                existing.PermanentUpazilaId = dto.PermanentUpazilaId;
                existing.PermanentVillage = dto.PermanentVillage;
                existing.PermanentRoad = dto.PermanentRoad;
                existing.PermanentHouse = dto.PermanentHouse;

                existing.CurrentCountry = dto.CurrentCountry;
                existing.CurrentDivision = dto.CurrentDivision;
                existing.CurrentDivisionId = dto.CurrentDivisionId;
                existing.CurrentUpazila = dto.CurrentUpazila;
           
                existing.CurrentUpazilaId = dto.CurrentUpazilaId;
                existing.CurrentRoad = dto.CurrentRoad;
                existing.CurrentHouse = dto.CurrentHouse;

                existing.Hometown = dto.Hometown;
                existing.IsSameAddress = dto.IsSameAddress;
                existing.UpdatedOn = DateTime.UtcNow;

                await _context.SaveChangesAsync();

                return Ok(new { message = "Address updated successfully", id = existing.Id });
            }

            // INSERT new
            var entity = new UserAddress
            {
                UserId = dto.UserId,
                PermanentCountry = dto.PermanentCountry,
                PermanentDivision = dto.PermanentDivision,
                PermanentDivisionId = dto.PermanentDivisionId,
                PermanentDistrict = dto.PermanentDistrict,
                PermanentDistrictId = dto.PermanentDistrictId,
                PermanentUpazila = dto.PermanentUpazila,
                PermanentUpazilaId = dto.PermanentUpazilaId,
                PermanentVillage = dto.PermanentVillage,
                PermanentRoad = dto.PermanentRoad,
                PermanentHouse = dto.PermanentHouse,

                CurrentCountry = dto.CurrentCountry,
                CurrentDivision = dto.CurrentDivision,
                CurrentDivisionId= dto.CurrentDivisionId,
                CurrentDistrict = dto.CurrentDistrict,
                CurrentDistrictId =dto.CurrentDistrictId,
                CurrentUpazila = dto.CurrentUpazila,
                CurrentUpazilaId =dto.CurrentUpazilaId, 
                CurrentVillage = dto.CurrentVillage,
                CurrentRoad = dto.CurrentRoad,
                CurrentHouse = dto.CurrentHouse,

                Hometown = dto.Hometown,
                IsSameAddress = dto.IsSameAddress,
                CreatedOn = DateTime.UtcNow,
                UpdatedOn = DateTime.UtcNow
            };

            _context.UserAddresses.Add(entity);
            await _context.SaveChangesAsync();

            return Ok(new { message = "Address saved successfully", id = entity.Id });
        }



        // GET BY USER ID
        [HttpGet("address/{userId}")]
        public async Task<IActionResult> GetAddress(int userId)
        {
            var data = await _context.UserAddresses
                .FirstOrDefaultAsync(x => x.UserId == userId);

            if (data == null)
                return NotFound(new { message = "Address not found" });

            return Ok(data);
        }

        [HttpPost("saveEducation")]
        public async Task<IActionResult> SaveOrUpdateEducation([FromBody] EducationDto dto)
        {
            if (dto == null || dto.UserId <= 0)
                return BadRequest("Invalid education data");

            // 🔍 Check existing record
            var education = await _context.UserEducations
                .FirstOrDefaultAsync(x => x.UserId == dto.UserId);

            if (education == null)
            {
                // ➕ INSERT
                education = new UserEducation
                {
                    UserId = dto.UserId,
                    CreatedOn = DateTime.UtcNow
                };

                _context.UserEducations.Add(education);
            }
            else
            {
                // ✏ UPDATE
                education.ModifiedOn = DateTime.UtcNow;
            }

            // 🔄 Common mapping
            education.Method = dto.Method;
            education.HighestDegree = dto.HighestDegree;

            education.SscPY = dto.SscPY;
            education.SscGroup = dto.SscGroup;
            education.SscResult = dto.SscResult;
            education.SscInsName = dto.SscInsName;

            education.HscPY = dto.HscPY;
            education.HscGroup = dto.HscGroup;
            education.HscResult = dto.HscResult;
            education.HscInsName = dto.HscInsName;

            education.UgPY = dto.UgPY;
            education.GSubject = dto.GSubject;
            education.UgInsName = dto.UgInsName;

            education.OtherDetails = dto.OtherDetails;

            await _context.SaveChangesAsync();
            await CompleteStep(3);
            return Ok(new
            {
                message = education.Id > 0 ? "Education details saved successfully" : "Education details updated successfully",
                educationId = education.Id
            });


        }
        [HttpGet("get-by-user/{userId}")]
        public async Task<IActionResult> GetEducationByUserId(int userId)
        {
            if (userId <= 0)
                return BadRequest("Invalid user id");

            var education = await _context.UserEducations
                .AsNoTracking()
                .FirstOrDefaultAsync(x => x.UserId == userId);

            if (education == null)
                return Ok(null); // no record yet

            var result = new EducationDto
            {
                UserId = education.UserId,
                Method = education.Method,
                HighestDegree = education.HighestDegree,

                SscPY = education.SscPY,
                SscGroup = education.SscGroup,
                SscResult = education.SscResult,
                SscInsName = education.SscInsName,

                HscPY = education.HscPY,
                HscGroup = education.HscGroup,
                HscResult = education.HscResult,
                HscInsName = education.HscInsName,

                UgPY = education.UgPY,
                GSubject = education.GSubject,
                UgInsName = education.UgInsName,

                OtherDetails = education.OtherDetails
            };

            return Ok(result);
        }

        [HttpPost("savePersonalInfo")]
        public async Task<IActionResult> Save([FromForm] PersonalInfoDto dto)
        {
            var info = await _context.PersonalInfos
                .FirstOrDefaultAsync(x => x.UserId == dto.UserId);

            if (info == null)
            {
                info = new PersonalInfo { UserId = dto.UserId };
                _context.PersonalInfos.Add(info);
            }

            info.DressOutside = dto.DressOutside;
            info.DiseaseInfo = dto.DiseaseInfo;
            info.SpecialWork = dto.SpecialWork;
            info.AboutYourself = dto.AboutYourself;
            info.MobileNo = dto.MobileNo;
            info.ModifiedOn = DateTime.UtcNow;

            if (dto.Selfie != null)
            {
                var folder = Path.Combine(_env.ContentRootPath, "wwwroot", "selfies");
                Directory.CreateDirectory(folder);
             

                var fileName = $"{Guid.NewGuid()}{Path.GetExtension(dto.Selfie.FileName)}";
                var path = Path.Combine(folder, fileName);

                using var stream = new FileStream(path, FileMode.Create);
                await dto.Selfie.CopyToAsync(stream);

                info.SelfiePath = fileName;
            }
          
            await _context.SaveChangesAsync();
            await CompleteStep(5);
            return Ok();
        }

        [HttpGet("get-personalinfo-by-user/{userId}")]
        public async Task<IActionResult> GetPersonalInfoByUserId(int userId)
        {
            if (userId <= 0)
                return BadRequest("Invalid user id");

            var info = await _context.PersonalInfos
                .AsNoTracking()
                .FirstOrDefaultAsync(x => x.UserId == userId);

            if (info == null)
                return Ok(null);

            var result = new
            {
                userId = info.UserId,
                dressOutside = info.DressOutside,
                diseaseInfo = info.DiseaseInfo,
                specialWork = info.SpecialWork,
                aboutYourself = info.AboutYourself,
                mobileNo = info.MobileNo,
                selfieUrl = string.IsNullOrEmpty(info.SelfiePath)
                    ? null
                    : $"{Request.Scheme}://{Request.Host}/api/selfies/{info.SelfiePath}"
            };

            return Ok(result);
        }
 
        [HttpPost("saveOccupation")]
        public async Task<IActionResult> SaveOrUpdate([FromBody] OccupationalInfoDto dto)
        {
            var existing = await _context.OccupationalInfos
                .FirstOrDefaultAsync(x => x.UserId == dto.UserId);

            if (existing == null)
            {
                var info = new OccupationalInfo
                {
                    UserId = dto.UserId,
                    Profession = dto.Profession,
                    ProfessionDetails = dto.ProfessionDetails,
                    MonthlyIncome = dto.MonthlyIncome
                };

                _context.OccupationalInfos.Add(info);
            }
            else
            {
                existing.Profession = dto.Profession;
                existing.ProfessionDetails = dto.ProfessionDetails;
                existing.MonthlyIncome = dto.MonthlyIncome;
                existing.ModifiedOn = DateTime.UtcNow;
            }

            await _context.SaveChangesAsync();
            await CompleteStep(6);
            return Ok(new
            {
                success = true,
                message = "Occupational information saved successfully"
            });
        }

        // Get by UserId (for edit / load)
        [HttpGet("get-occupation-by-user/{userId}")]
        public async Task<IActionResult> GetByUserId(int userId)
        {
            var data = await _context.OccupationalInfos
                .Where(x => x.UserId == userId)
                .Select(x => new OccupationalInfoDto
                {
                    UserId = x.UserId,
                    Profession = x.Profession,
                    ProfessionDetails = x.ProfessionDetails,
                    MonthlyIncome = x.MonthlyIncome
                })
                .FirstOrDefaultAsync();

            return Ok(data);
        }

        [HttpPost("saveContactInfo")]
        public async Task<IActionResult> SaveOrUpdate(
       [FromBody] BiodataContactDto dto)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var contact = await _context.BiodataContacts
                .FirstOrDefaultAsync(x => x.UserId == dto.UserId);

            if (contact == null)
            {
                // ➕ INSERT
                contact = new BiodataContact
                {
                    UserId = dto.UserId,
                    GroomName = dto.GroomName.Trim(),
                    GuardianMobile = dto.GuardianMobile.Trim(),
                    GuardianRelation = dto.GuardianRelation.Trim(),
                    BiodataEmail = dto.BiodataEmail.Trim(),
                    CreatedAt = DateTime.UtcNow
                };

                _context.BiodataContacts.Add(contact);
            }
            else
            {
                // ✏️ UPDATE
                contact.GroomName = dto.GroomName.Trim();
                contact.GuardianMobile = dto.GuardianMobile.Trim();
                contact.GuardianRelation = dto.GuardianRelation.Trim();
                contact.BiodataEmail = dto.BiodataEmail.Trim();
                contact.UpdatedAt = DateTime.UtcNow;
            }

            await _context.SaveChangesAsync();
            await CompleteStep(10);
            return Ok(new
            {
                success = true,
                message = contact.UpdatedAt == null
                    ? "Contact information saved successfully"
                    : "Contact information updated successfully"
            });
        }

        [HttpGet("get-contact-by-user/{userId}")]
        public async Task<IActionResult> GetContactByUserId(int userId)
        {
            if (userId <= 0)
                return BadRequest("Invalid user id");

            var contact = await _context.BiodataContacts
                .AsNoTracking()
                .Where(x => x.UserId == userId)
                .Select(x => new
                {
                    x.UserId,
                    x.GroomName,
                    x.GuardianMobile,
                    x.GuardianRelation,
                    x.BiodataEmail
                })
                .FirstOrDefaultAsync();

            if (contact == null)
            {
                return NotFound(new
                {
                    success = false,
                    message = "Contact information not found"
                });
            }

            return Ok(contact);
        }

        [HttpPost("profiles/search")]
        public async Task<IActionResult> SearchProfiles([FromBody] BiodataSearchRequest request)
        {
            var query =
                from ub in _context.UserBiodata
                join bc in _context.BiodataContacts on ub.UserId equals bc.UserId into bcj
                from bc in bcj.DefaultIfEmpty()

                join bg in _context.BiodataGeneralInfos on ub.UserId equals bg.UserId into bgj
                from bg in bgj.DefaultIfEmpty()

                join oc in _context.OccupationalInfos on ub.UserId equals oc.UserId into ocj
                from oc in ocj.DefaultIfEmpty()

                join p in _context.PersonalInfos on ub.UserId equals p.UserId into pj
                from p in pj.DefaultIfEmpty()

                select new { ub, bc, bg, oc, p };
            if(request != null )
            {
                // Biodata No
                if (!string.IsNullOrEmpty(request.BiodataNo))
                    query = query.Where(x => x.ub.BiodataNo.Contains(request.BiodataNo));

                // Biodata Type
                if (!string.IsNullOrEmpty(request.BiodataType))
                    query = query.Where(x => x.bg.BiodataType == request.BiodataType);

                // Marital Status
                if (!string.IsNullOrEmpty(request.MaritalStatus))
                    query = query.Where(x => x.bg.MaritalStatus == request.MaritalStatus);
                if(request.AgeMin>0)
                {
                    // Age Range
                    query = query.Where(x =>
                        x.bg.Age >= request.AgeMin &&
                        x.bg.Age <= request.AgeMax);
                }
              
            }
            

            var result = await query.Select(x => new BiodataProfileDto
            {
                bioDataCode = x.ub.BiodataNo,
                GroomName = x.bc.GroomName,
                Age = x.bg.Age,
                Height = x.bg.Height,
                Profession = x.oc.Profession,
                Avatar = string.IsNullOrEmpty(x.p.SelfiePath)
                    ? null
                    : $"{Request.Scheme}://{Request.Host}/api/selfies/{x.p.SelfiePath}"
            }).ToListAsync();

            return Ok(new { success = true, data = result });
        }
        [HttpGet("steps")]
        public async Task<IActionResult> GetSteps()
        {
            int userId = int.Parse(User.FindFirst(ClaimTypes.NameIdentifier).Value);

            var steps = await (
                from s in _context.BioSteps
                where s.IsActive
                orderby s.StepOrder
                join p in _context.UserBioStepProgress
                    .Where(x => x.UserId == userId)
                    on s.StepId equals p.StepId into sp
                from p in sp.DefaultIfEmpty()
                select new BioStepDto
                {
                    StepId = s.StepId,
                    StepName = s.StepName,
                    StepOrder = s.StepOrder,
                    IsCompleted = p != null && p.IsCompleted
                }
            ).ToListAsync();

            // 🔒 Lock logic
            bool unlockNext = true;
            foreach (var step in steps)
            {
                step.IsAccessible = unlockNext;
                if (!step.IsCompleted)
                    unlockNext = false;
            }

            return Ok(steps);
        }

     
        private async Task<IActionResult> CompleteStep(int stepId)
        {
            int userId = int.Parse(User.FindFirst(ClaimTypes.NameIdentifier).Value);

            var biodata = await _context.UserBiodata
                .FirstOrDefaultAsync(x => x.UserId == userId && x.Status == "Draft");

            if (biodata == null)
                return BadRequest("No active biodata");

            var progress = await _context.UserBioStepProgress
                .FirstOrDefaultAsync(x =>
                    x.UserId == userId &&
                    x.BiodataId == biodata.Id &&
                    x.StepId == stepId);

            if (progress == null)
            {
                progress = new UserBioStepProgress
                {
                    UserId = userId,
                    BiodataId = biodata.Id,
                    StepId = stepId,
                    IsCompleted = true,
                    CompletedOn = DateTime.Now
                };
                _context.UserBioStepProgress.Add(progress);
            }
            else
            {
                progress.IsCompleted = true;
                progress.CompletedOn = DateTime.Now;
            }

            // 🔍 Check if all steps are completed
            int totalSteps = await _context.BioSteps.CountAsync(x => x.IsActive);
            int completedSteps = await _context.UserBioStepProgress
                .CountAsync(x => x.BiodataId == biodata.Id && x.IsCompleted);

            if (completedSteps + 1 == totalSteps)
            {
                biodata.Status = "Completed";
                biodata.CompletedOn = DateTime.Now;
            }

            await _context.SaveChangesAsync();
            return Ok();
        }

        [HttpPost("start")]
        public async Task<IActionResult> StartBiodata()
        {
            int userId = int.Parse(User.FindFirst(ClaimTypes.NameIdentifier).Value);

            // Check existing biodata
            var existing = await _context.UserBiodata
                .FirstOrDefaultAsync(x => x.UserId == userId && x.Status != "UnderReview");

            if (existing != null)
                return Ok(existing);

            int nextId = (_context.UserBiodata.Max(x => (int?)x.Id) ?? 0) + 1;

            var biodata = new UserBiodata
            {
                UserId = userId,
                BiodataNo = GenerateBiodataNo(nextId),
                Status = "Draft",
                CreatedOn = DateTime.Now
            };

            _context.UserBiodata.Add(biodata);
            await _context.SaveChangesAsync();

            return Ok(biodata);
        }

        [HttpGet("status")]
        public async Task<IActionResult> GetBiodataStatus()
        {
            int userId = int.Parse(User.FindFirst(ClaimTypes.NameIdentifier).Value);

            var biodata = await _context.UserBiodata
                .FirstOrDefaultAsync(x => x.UserId == userId);

            if (biodata == null)
                return NotFound("Biodata not started");

            int totalSteps = await _context.BioSteps.CountAsync(x => x.IsActive);

            int completedSteps = await _context.UserBioStepProgress
                .CountAsync(x =>
                    x.BiodataId == biodata.Id &&
                    x.IsCompleted);

            bool isCompleted = completedSteps == totalSteps;

            return Ok(new
            {
                biodata.BiodataNo,
                biodata.Status,
                TotalSteps = totalSteps,
                CompletedSteps = completedSteps,
                IsReadyForReview = isCompleted
            });
        }

        private string GenerateBiodataNo(int nextId)
        {
            return $"BIO-{DateTime.Now.Year}-{nextId.ToString().PadLeft(6, '0')}";
        }

        [HttpGet("details/{biodataNo}")]
        public async Task<IActionResult> GetBiodataDetails(string biodataNo)
        {
            var data = await (
                from ub in _context.UserBiodata
                join u in _context.Users on ub.UserId equals u.Id
                join g in _context.BiodataGeneralInfos on u.Id equals g.UserId
                join p in _context.PersonalInfos on u.Id equals p.UserId
                join o in _context.OccupationalInfos on u.Id equals o.UserId
                join e in _context.UserEducations on u.Id equals e.UserId
                join a in _context.UserAddresses on u.Id equals a.UserId
                join c in _context.BiodataContacts on u.Id equals c.UserId
                where ub.BiodataNo == biodataNo
                select new BiodataDetailDto
                {
                    BiodataNo = ub.BiodataNo,
                    Status = ub.Status,

                    Name = u.Name,
                    Email = u.Email,

                    GeneralInfo = new GeneralInfoDto
                    {
                        BiodataType = g.BiodataType,
                        MaritalStatus = g.MaritalStatus,
                        Age = g.Age,
                        Height = g.Height,
                        SkinTone = g.SkinTone,
                        BloodGroup = g.BloodGroup
                    },

                    PersonalInfo = new PersonalInfo
                    {
                        AboutYourself = p.AboutYourself,
                        MobileNo = p.MobileNo,
                     
                       SelfiePath = string.IsNullOrEmpty(p.SelfiePath)
                        ? null
                        : $"{Request.Scheme}://{Request.Host}/api/selfies/{p.SelfiePath}"
                        },

                    OccupationalInfo = new OccupationalInfoDto
                    {
                        Profession = o.Profession,
                        MonthlyIncome = o.MonthlyIncome
                    },

                    Education = new EducationDto
                    {
                        HighestDegree = e.HighestDegree,
                        GSubject = e.GSubject
                    },

                    Address = new AddressDto
                    {
                        PermanentDistrict = a.PermanentDistrict,
                        CurrentDistrict = a.CurrentDistrict
                    },

                    Contact = new BiodataContactDto
                    {
                        GroomName = c.GroomName,
                        GuardianMobile = c.GuardianMobile,
                        GuardianRelation = c.GuardianRelation
                    }
                }
            ).FirstOrDefaultAsync();

            if (data == null)
                return NotFound(new { message = "Biodata not found" });

            return Ok(data);
        }

    }
}
