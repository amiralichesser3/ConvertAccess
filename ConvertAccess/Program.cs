using System;
using System.Collections.Generic;
using System.Data;
using System.Data.OleDb; 
using MadarshoX.Model.Models.Product;

namespace ConvertAccess
{
    class Program
    {
        static void Main(string[] args)
        {
            string strDSN = "Provider=Microsoft.ACE.OLEDB.12.0;Data Source = C:\\acc\\product.accdb";
            string strSQL_Brand = "SELECT * FROM Brand";
            string stySQL_Category = "SELECT * FROM Category";
            string stySQL_Feature = "SELECT * FROM Feature";
            string stySQL_SuitableFor = "SELECT * FROM SuitableFor"; 
            string stySQL_Item = "SELECT * FROM Item"; 
            string stySQL_FeatureItem = "SELECT * FROM FeatureItem"; 
            // create Objects of ADOConnection and ADOCommand  
            OleDbConnection myConn = new OleDbConnection(strDSN);
            OleDbDataAdapter myCmd = new OleDbDataAdapter(strSQL_Brand, myConn);
           
            DataSet ds = new DataSet();
            try
            {
                myConn.Open();
                myCmd.Fill(ds);
                var brandList = new List<Brand>();
                var categoryList = new List<Category>();
                var features = new List<Feature>();
                var suitableFors = new List<SuitableFor>();
                var accItems = new List<AccItem>();
                var items = new List<Item>();
                var featureItems = new List<FeatureItem>();
//                for (var i = 0; i <= ds.Tables[0].Rows.Count - 1; i++)
//                {
//                    brandList.Add(new Brand {
//                        BrandId = (int)ds.Tables[0].Rows[i].ItemArray[0],
//                        Name = (string)ds.Tables[0].Rows[i].ItemArray[1]
//                    });
//                }
//                ds = new DataSet();
//                myCmd.Dispose();
//                myCmd = new OleDbDataAdapter(stySQL_Category, myConn);
//                myCmd.Fill(ds);
//                for (var i = 0; i <= ds.Tables[0].Rows.Count - 1; i++)
//                {
//                    var category = new Category
//                    {
//                        CategoryId = (int)ds.Tables[0].Rows[i].ItemArray[0],
//                        Name = (string)ds.Tables[0].Rows[i].ItemArray[1] 
//                    };
//                    try
//                    {
//                        category.ParentId = (int)ds.Tables[0].Rows[i].ItemArray[2];
//                    }
//                    catch(Exception ex)
//                    {
//
//                    }
//                    categoryList.Add(category);
//                }
//
//                ds = new DataSet();
//                myCmd.Dispose();
//                myCmd = new OleDbDataAdapter(stySQL_Feature, myConn);
//                myCmd.Fill(ds);
//                for (var i = 0; i <= ds.Tables[0].Rows.Count - 1; i++)
//                {
//                    var feature = new Feature((int)ds.Tables[0].Rows[i].ItemArray[0], (string)ds.Tables[0].Rows[i].ItemArray[1]); 
//                    features.Add(feature);
//                }
//
//                ds = new DataSet();
//                myCmd.Dispose();
//                myCmd = new OleDbDataAdapter(stySQL_SuitableFor, myConn);
//                myCmd.Fill(ds);
//                for (var i = 0; i <= ds.Tables[0].Rows.Count - 1; i++)
//                {
//                    var suitableFor = new SuitableFor
//                    {
//                        SuitableForId = (int)ds.Tables[0].Rows[i].ItemArray[0],
//                        Name = (string)ds.Tables[0].Rows[i].ItemArray[1],
//                        ParentId = null
//                    };
//                    suitableFors.Add(suitableFor);
//                }

                ds = new DataSet();
                myCmd.Dispose();
                myCmd = new OleDbDataAdapter(stySQL_FeatureItem, myConn);
                myCmd.Fill(ds);
                for (var i = 0; i <= 20; i++)
                {
                    var featureItem = new FeatureItem
                    {
                        FeatureId = (int)ds.Tables[0].Rows[i].ItemArray[1],
                        ItemId = (int)ds.Tables[0].Rows[i].ItemArray[2],
                        
                    };

                    try
                    {
                        featureItem.Value = (string) ds.Tables[0].Rows[i].ItemArray[4];
                    }
                    catch (Exception e)
                    {
                      //Ignored
                    }

                    try
                    {
                        var typeString = (string) ds.Tables[0].Rows[i].ItemArray[3];
                        if (typeString.Equals("اختصاصی"))
                        {
                            featureItem.FeatureItemType = 2;
                        }
                        else if (typeString.Equals("مشخصاتی که کاربر باید امتیاز دهد"))
                        {
                            featureItem.FeatureItemType = 4;
                        }
                        else if(typeString.Equals("عمومی"))
                        {
                            featureItem.FeatureItemType = 1;
                        }
                    }
                    catch (Exception e)
                    {
                      //Ignored
                    } 
                    
                    featureItems.Add(featureItem);
                }

                ds = new DataSet();
                myCmd.Dispose();
                myCmd = new OleDbDataAdapter(stySQL_Item, myConn);
                myCmd.Fill(ds);
                for (var i = 0; i <= ds.Tables[0].Rows.Count - 1; i++)
                {
                    var accItem = new AccItem();

                    accItem.ItemId = (int) ds.Tables[0].Rows[i].ItemArray[0];
                    accItem.ItemCode = (string) ds.Tables[0].Rows[i].ItemArray[1];
                    try
                    {
                        accItem.ItemName = (string) ds.Tables[0].Rows[i].ItemArray[2];
                    }
                    catch (Exception e)
                    {
                        accItem.ItemName = "null";
                    }
                  
                    accItem.CategoryId = (int) ds.Tables[0].Rows[i].ItemArray[3];
                    accItem.BrandId = (int) ds.Tables[0].Rows[i].ItemArray[4]; 
                    accItem.ImageNames =  ((string) ds.Tables[0].Rows[i].ItemArray[7]).Split(';');
                    try
                    {
                        accItem.SuitableForId = (int)ds.Tables[0].Rows[i].ItemArray[5];
                    }
                    catch (Exception e)
                    {
                    
                    }

                    if (accItem.ItemId >= 1200)
                    {
                        accItems.Add(accItem);
                    } 
                }

                foreach (var accItem in accItems)
                {
                    var item = new Item();
                    item.ItemId = accItem.ItemId;
                    item.Name = accItem.ItemName;
                    item.BrandId = accItem.BrandId;
                    item.CategoryId = accItem.CategoryId;
                    //in the db all items have one or less suitableForIds
                    if (accItem.SuitableForId != 0)
                    {
                        item.SuitableForItems = new List<SuitableForItem>{ new SuitableForItem(item.ItemId,  (long)accItem.SuitableForId) };
                    } 
                    
                    //images are already uploaded, so we get their url and save them to db to get an Id and add them to item's imageItems with the images' Ids
                    item.ImageItems = new List<ImageItem>();
                    using (var db = new AppDbContext())
                    { 
                        int i = 0;
                        foreach (var imageName in accItem.ImageNames)
                        {
                            var image = new Image
                            {
                                ImageType = 1,
                                Url = GetUrl(imageName)
                            };

                            db.Images.Add(image);
                            db.SaveChanges();
                            if (i == 0)
                            {
                                item.FeaturedImageId = image.ImageId;
                                i++;
                            }
                            else
                            {
                                item.ImageItems.Add(new ImageItem{ ImageId = image.ImageId });
                            } 
                        }
                    }
                    
                    items.Add(item);
                }
                
                myConn.Close();
                using (var db = new AppDbContext())
                {
                    //db.Brands.AddRange(brandList);
                    //db.Categories.AddRange(categoryList);
                    //db.Features.AddRange(features);
                    //db.SuitableFors.AddRange(suitableFors);
                    db.Items.AddRange(items);
                    db.SaveChanges();
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            Console.WriteLine("Done!");
            Console.Read();
        }

        private static string GetUrl(string imageName)
        {
            return "http://79.175.169.197:6001/img/" + imageName;
        }
    }
}
