﻿using System;
using System.Collections.Generic;
using System.Data.Entity.Core.Objects;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;
using FotoAppDB.DBModel;
using FotoAppDBTest;

namespace FotoAppTest
{
    class Program
    {
        static void Main(string[] args)
        {
            FotoAppRAll cont = FotoAppRAll.Ins;

            var cos1 = cont.Types.GetAll(true);
            var cos2 = cont.Sizes.GetSizesByType(cos1[0], true);

            cont.Settings.CheckLangSettings();


            //Addsetings(all); //dodaje setings
            foreach (var e in cos1)
            {

                try
                {
                    Console.WriteLine(@"{0} {1}", e.TypeID, cont.TypeTexts.GetTypeTextByTypeALang(e, new Languages() { Language = "en" }).Text);
                }
                catch (Exception exception)
                {
                    Console.WriteLine(@"{0} dfgkjgfdkfgdg", e.TypeID);
                }
            }



            foreach (Types aa in cos1)
            {
                Console.WriteLine(aa.TypeID.ToString());
                Console.WriteLine(aa.TypeTexts.ToString());
            }
            Console.WriteLine(cont.SizeTexts.GetSizeTextBySizeALang(new Sizes() { Height = 900, Length = 1300 }, new Languages() { Language = "pl_PL" }).Text);
            
            cont.Settings.CheckLangSettings();
            var cos = cont.Settings.GetAll();

            foreach (var e in cos)
            {
                Console.WriteLine(e.Value);
            }
            Console.WriteLine(cont.Languages);
            
            
            
            Console.ReadKey();

        }

        private static void Addsetings(FotoAppRAll all)
        {
            //Settings s = new Settings() { Area = "lang", Target = "pl_en", Value = "pl_PL" };
            //var s = all.Settings.Get()
            //all.Settings.Update(s);
        }
    }
}
