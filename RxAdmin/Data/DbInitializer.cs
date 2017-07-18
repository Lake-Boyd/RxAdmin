using RxAdmin.Models;
using System;
using System.Linq;

namespace RxAdmin.Data
{
    public static class DbInitializer
    {
        public static void Initialize(HospitalContext context)
        {
            context.Database.EnsureCreated();

            // Look for any meds or rxs.
            if (context.Rxs.Any())
            {
                return;   // DB has been seeded
            }



            var doctors = new Doctor[]
            {
            new Doctor{FirstName="Buster", LastName="Maddox", Specialty="Oncology", PhoneNumber="801-555-6395"},
            new Doctor{FirstName="Ben", LastName="Hansen", Specialty="Cardiology", PhoneNumber="801-875-6065"},
            new Doctor{FirstName="Ben", LastName="Hansen", Specialty="Cardiology", PhoneNumber="801-875-6065"}
            };
            foreach (Doctor c in doctors)
            {
                context.Doctors.Add(c);
            }
            context.SaveChanges();

            var patients = new Patient[]
            {
            new Patient{DoctorID=1, Condition="Good", FirstName="Buster",LastName="Maddox",Age=66, Gender="Male", Street="1921 Pecan Valley Dr", City="Cedar Park", State="Texas", Zip=78641},
            new Patient{DoctorID=1, Condition="Stable", FirstName="Chuck",LastName="Barry",Age=56, Gender="Male", Street="6030 E Selkirk Cir.", City="Mesa", State="Arizona", Zip=85213},
            new Patient{DoctorID=1, Condition="Critical", FirstName="Tom",LastName="McFarlane",Age=72, Gender="Male", Street="20448 Brahms Blvd", City="San Diego", State="California", Zip=90619},
            new Patient{DoctorID=1, Condition="Serious", FirstName="Lana",LastName="Ford",Age=71, Gender="Female", Street="3024 Abbot Kinney Dr", City="Los Angeles", State="California", Zip=90442},
            new Patient{DoctorID=1, Condition="Good", FirstName="Gern",LastName="Blandstein",Age=56, Gender="Male", Street="2087 Marble Slab Dr", City="Cedar Park", State="Texas", Zip=78641},
            new Patient{DoctorID=1, Condition="Serious", FirstName="Bethany",LastName="Mayfair",Age=86, Gender="Female", Street="2006 Badger Ln", City="Leander", State="Texas", Zip=78641}
            };
            foreach (Patient c in patients)
            {
                context.Patients.Add(c);
            }
            context.SaveChanges();

            var rxs = new Rx[]
            {
            new Rx{PatientID=1, Email=true, FillDate=DateTime.Parse("2005-09-01"), RefillDate=DateTime.Parse("2005-12-01"), RxDose=200, RxName="Oxycodone",Text=false},
            new Rx{PatientID=1, Email=true, FillDate=DateTime.Parse("2005-09-01"), RefillDate=DateTime.Parse("2005-12-01"), RxDose=100, RxName="Codeine",Text=false},
            new Rx{PatientID=1, Email=true, FillDate=DateTime.Parse("2005-09-01"), RefillDate=DateTime.Parse("2005-12-01"), RxDose=100, RxName="Tramadol",Text=false},
            new Rx{PatientID=1, Email=true, FillDate=DateTime.Parse("2005-09-01"), RefillDate=DateTime.Parse("2005-12-01"), RxDose=200, RxName="Quinapril",Text=false},
            new Rx{PatientID=1, Email=true, FillDate=DateTime.Parse("2005-09-01"), RefillDate=DateTime.Parse("2005-12-01"), RxDose=200, RxName="Quinapril",Text=false},
            new Rx{PatientID=1, Email=true, FillDate=DateTime.Parse("2005-09-01"), RefillDate=DateTime.Parse("2005-12-01"), RxDose=100, RxName="Tramadol",Text=false}

            };
            foreach (Rx s in rxs)
            {
                context.Rxs.Add(s);
            }
            context.SaveChanges();

        }
    }
}
