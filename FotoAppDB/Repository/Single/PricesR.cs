﻿using FotoAppDB.Exception;
using FotoAppDB.DBModel;

namespace FotoAppDB.Repository.Single
{
    public class PricesR : FotoAppR<FotoAppDbContext, Prices>
    {
        public override Prices Get(Prices FAobject)
        {
            Prices o = Context.Price.Find(FAobject.SizeID, FAobject.TypeID, FAobject.Quantity);
            if (o != null)
            {
                FAobject = o;
                return o;
            }
            else
            {
                throw new NotExistInDataBaseException("Brak ceny!");
            }
        }

        public override bool Is(Prices FAobject)
        {
            return Context.Price.Find(FAobject.SizeID, FAobject.TypeID, FAobject.Quantity) != null;
        }
    }
}
