using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using RigoAccounts.DLL;

namespace RigoAccounts.BLL.Manager
{
    public class ItemManager
    {

        public static bool insertItem(ItemOrProduct itm, bool isInsert) {

            bool status = false;

            if (itm != null) {

                SampleDatabaseDataContext dc = new SampleDatabaseDataContext();

                if (isInsert)
                {
                    itm.CreatedOn = DateTime.Now;
                    dc.ItemOrProducts.InsertOnSubmit(itm);
                }

                else {

                    ItemOrProduct dbItem = dc.ItemOrProducts.Where(x => x.ItemID==itm.ItemID).SingleOrDefault();
                    dbItem.Name = itm.Name;
                    dbItem.PurchasePrice = itm.PurchasePrice;
                    dbItem.SalesPrice = itm.SalesPrice;
                    dbItem.OpeningQty = itm.OpeningQty;
                    dbItem.InStock = itm.InStock;
                }

                dc.SubmitChanges();
                status = true;
            }

            return status;
        }

        public static ItemOrProduct getItemById(Guid id) {

            SampleDatabaseDataContext dc = new SampleDatabaseDataContext();
            return dc.ItemOrProducts.Where(x=>x.ItemID==id).SingleOrDefault();
        }

        public static bool deleteItem(ItemOrProduct Itm) {

            bool status = false;

            if (Itm != null) {

                SampleDatabaseDataContext dc = new SampleDatabaseDataContext();

                ItemOrProduct dbItem = dc.ItemOrProducts.Where(x => x.ItemID == Itm.ItemID).SingleOrDefault();
                dc.ItemOrProducts.DeleteOnSubmit(dbItem);
                dc.SubmitChanges();
                status = true;
            }
            return status;
        }

        public static List<ItemOrProduct> getAllItems() {

            SampleDatabaseDataContext dc = new SampleDatabaseDataContext();

            return dc.ItemOrProducts.ToList();
        }
    }
}