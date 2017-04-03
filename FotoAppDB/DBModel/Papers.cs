﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Data.Entity;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace FotoAppDB.DBModel
{
    public class Papers : IDBModel
    {
        public Papers()
        {
            this.Sizes = new HashSet<Sizes>();
            this.Types = new HashSet<Types>();
        }
        [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int PaperID { get; set; }
        public virtual ICollection<Sizes> Sizes { get; set; }
        public virtual ICollection<Types> Types { get; set; }

        public void Add(FotoAppDbContext db)
        {
            db.Paper.Add(this);
            db.SaveChanges();
        }

        public bool Is(FotoAppDbContext db)
        {
            return db.Paper.Find(this.PaperID) != null;
        }
        public static bool Is(FotoAppDbContext db, int id)
        {
            return db.Paper.Find(id) != null;
        }

        public void Remove(FotoAppDbContext db)
        {
            throw new NotImplementedException();
        }
    }
}
