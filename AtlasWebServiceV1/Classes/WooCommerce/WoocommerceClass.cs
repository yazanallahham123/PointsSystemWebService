using PointsSystemWebService.Classes.Core;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using System.Web;
using System.Windows.Media;
using WooCommerceNET;
using WooCommerceNET.WooCommerce.v3;
using WooCommerceNET.WooCommerce.v3.Extension;

namespace PointsSystemWebService.Classes.WooCommerce
{
    public class WoocommerceClass
    {
        /*public async Task<ProductList> GetAllProducts()
        {
            ProductList allProducts = new ProductList();

            ServicePointManager.SecurityProtocol = SecurityProtocolType.Tls12;
            RestAPIHelper rest = new RestAPIHelper("https://woocommercetest.developitech.com/wp-json/wc/v3/", "ck_ee196b2f55e551b43b58fd8792b6cc11346adba7", "cs_0fd7b024cbcb7b3949a2bd1460f843d0ef4baa52");
            WCObject wc = new WCObject(rest);

            Dictionary<string, string> dic = new Dictionary<string, string>();
            int PageNumber = 1;
            dic.Add("per_page", "10");
            dic.Add("page", PageNumber.ToString());

            bool endOfProducts = false;

            while (!endOfProducts)
            {
                var products = await wc.GetProducts(dic);
                if (products.Count > 0)
                {
                    allProducts.AddRange(products);
                    PageNumber++;
                    dic["page"] = PageNumber.ToString();
                }
                else
                    endOfProducts = true;
            }
            return allProducts;
        }*/

        public async Task<List<Product>> AsyncAllProducts(List<ItemClass> storeItems)
        {
            ServicePointManager.SecurityProtocol = SecurityProtocolType.Tls12;
            RestAPIHelper rest = new RestAPIHelper("https://woocommercetest.developitech.com/wp-json/wc/v3/", "ck_ee196b2f55e551b43b58fd8792b6cc11346adba7", "cs_0fd7b024cbcb7b3949a2bd1460f843d0ef4baa52");
            WCObject wc = new WCObject(rest);

            List<Product> allWooProducts;
            allWooProducts = await wc.Product.GetAll();

            foreach (ItemClass item in storeItems)
            {
                Product xx = allWooProducts.Find(i => i.sku.Equals(item.Code));

                if (xx != null)
                {
                    await UpdateProduct((int)xx.id, GetItemData(7, item.Id).Result);
                }
                else
                {
                    await AddProduct(GetItemData(7, item.Id).Result);
                }
            }
            
            return null;
        }

        public async Task<Product> AddProduct(ItemsDataClass item)
        {
            ServicePointManager.SecurityProtocol = SecurityProtocolType.Tls12;
            RestAPIHelper rest = new RestAPIHelper("https://woocommercetest.developitech.com/wp-json/wc/v3/", "ck_ee196b2f55e551b43b58fd8792b6cc11346adba7", "cs_0fd7b024cbcb7b3949a2bd1460f843d0ef4baa52");
            WCObject wc = new WCObject(rest);
            Product wooProduct = ItemToProduct(item);

            var res = await wc.Product.Add(wooProduct);

            List<Variation> varlist = ItemDataToVariations(item);

            foreach (var iv in varlist)
            {
                int id = (int)res.id;
                await wc.Product.Variations.Add(iv, id);
            }

            return res;
        }

        public async Task<Product> UpdateProduct(int wooId, ItemsDataClass item)
        {
            ServicePointManager.SecurityProtocol = SecurityProtocolType.Tls12;
            RestAPIHelper rest = new RestAPIHelper("https://woocommercetest.developitech.com/wp-json/wc/v3/", "ck_ee196b2f55e551b43b58fd8792b6cc11346adba7", "cs_0fd7b024cbcb7b3949a2bd1460f843d0ef4baa52");
            WCObject wc = new WCObject(rest);
            Product wooProduct = ItemToProduct(item);

            var res = await wc.Product.Update(wooId, wooProduct);

            List<Variation> varlist = await wc.Product.Variations.GetAll(wooId);
            foreach (var vr in varlist)
            {
                int vid = (int)vr.id;
                await wc.Product.Variations.Delete(vid, wooId);
            }

            varlist = ItemDataToVariations(item);

            foreach (var iv in varlist)
            {
                int id = (int)res.id;
                await wc.Product.Variations.Add(iv, id);
            }

            return res;
        }

        public Product ItemToProduct(ItemsDataClass item)
        {
            Product product = new Product();
            product.name = item.ItemClass.EnglishName;
            product.sku = item.ItemClass.Code;
            product.regular_price = Convert.ToDecimal(item.ItemClass.Price);            
            product.description = item.ItemClass.EnglishDescription;
            if (item.ItemClass.OfferHasPriceOffer)
            {
                product.sale_price = 300;//Convert.ToDecimal(item.ItemClass.OfferPrice);
            }

            //Images
            if (item.Images.Count > 0)
            {
                int img_id = 0;
                product.images = new List<ProductImage>();
                foreach (var img in item.Images)
                {
                    img_id++;
                    ProductImage wooImage = new ProductImage();
                    wooImage.position = img.Order;
                    //wooImage.id = img_id;
                    wooImage.src = img.ImageUrl;
                    wooImage.alt = "alt" + img_id.ToString();
                    product.images.Add(wooImage);
                }
            }
            product.stock_status = "instock";
            product.manage_stock = true;
            product.stock_quantity = 100;
            product.catalog_visibility = "visible";
            product.type = "simple";


            //Attributes

                    


                    WooCommerceNET.WooCommerce.v3.ProductAttributeLine att;
                    //Sizes
                    if (item.Sizes != null)
                    {
                        if (item.Sizes.Count > 0)
                        {
                            if (product.attributes == null)
                                product.attributes = new List<ProductAttributeLine>();
                            product.type = "variable";

                            att = new WooCommerceNET.WooCommerce.v3.ProductAttributeLine();

                            att.name = "Size";
                            att.options = new List<string>();
                            foreach (var size in item.Sizes)
                            {
                                att.options.Add(size.SizeEnglishName);
                            }
                            att.variation = true;
                            att.visible = true;
                            att.position = 1;
                            product.attributes.Add(att);
                        }
                    }
                    //Colors
                    if (item.Colors != null)
                    {
                        if (item.Colors.Count > 0)
                        {
                            if (product.attributes == null)
                                product.attributes = new List<ProductAttributeLine>();
                            product.type = "variable";
                            att = new WooCommerceNET.WooCommerce.v3.ProductAttributeLine();
                            att.name = "Color";
                            att.options = new List<string>();
                            foreach (var color in item.Colors)
                            {
                                att.options.Add(color.ColorEnglishName);
                            }
                            att.variation = true;
                            att.visible = true;
                            att.position = 1;
                            product.attributes.Add(att);
                        }
                    }
            return product;            
        }

        public List<Variation> ItemDataToVariations(ItemsDataClass item)
        {
            List<WooCommerceNET.WooCommerce.v3.Variation> variations = new List<WooCommerceNET.WooCommerce.v3.Variation>();
            bool addColors = false;
            bool addSizes = false;

            if (item.Colors != null)
                if (item.Colors.Count > 0)
                    addColors = true;

            if (item.Sizes != null)
                if (item.Sizes.Count > 0)
                    addSizes = true;

            if (addColors && addSizes)
            {
                foreach (var color in item.Colors)
                {
                    foreach (var size in item.Sizes)
                    {
                        WooCommerceNET.WooCommerce.v3.Variation variation = new WooCommerceNET.WooCommerce.v3.Variation();
                        WooCommerceNET.WooCommerce.v3.VariationAttribute sizeAtt = new WooCommerceNET.WooCommerce.v3.VariationAttribute();
                        sizeAtt.name = "Size";
                        sizeAtt.option = size.SizeEnglishName;

                        WooCommerceNET.WooCommerce.v3.VariationAttribute colorAtt = new WooCommerceNET.WooCommerce.v3.VariationAttribute();
                        colorAtt.name = "Color";
                        colorAtt.option = color.ColorEnglishName;
                        variation.attributes = new List<VariationAttribute>();
                        variation.attributes.Add(colorAtt);
                        variation.attributes.Add(sizeAtt);
                        variation.manage_stock = true;
                        variation.stock_status = "instock";
                        variation.regular_price = 500;//Convert.ToDecimal(item.ItemClass.Price);
                        variation.sku = item.ItemClass.Code + color.ColorId.ToString() + size.SizeId.ToString();
                        variation.stock_quantity = 100;
                       

                        if (item.ItemClass.OfferHasPriceOffer)
                        {
                            variation.sale_price = 300;//Convert.ToDecimal(item.ItemClass.OfferPrice);
                        }
                        variations.Add(variation);
                        
                    }
                }
            }
            else
            {
                if (addSizes)
                {
                    foreach (var size in item.Sizes)
                    {
                        WooCommerceNET.WooCommerce.v3.Variation variation = new WooCommerceNET.WooCommerce.v3.Variation();
                        WooCommerceNET.WooCommerce.v3.VariationAttribute sizeAtt = new WooCommerceNET.WooCommerce.v3.VariationAttribute();
                        sizeAtt.name = "Size";
                        sizeAtt.option = size.SizeEnglishName;
                        variation.attributes = new List<VariationAttribute>();
                        variation.attributes.Add(sizeAtt);
                        variation.manage_stock = true;
                        variation.stock_status = "instock";
                        variation.regular_price = 500;//Convert.ToDecimal(item.ItemClass.Price);
                        variation.sku = item.ItemClass.Code + size.SizeId.ToString();
                        variation.stock_quantity = 100;

                        if (item.ItemClass.OfferHasPriceOffer)
                        {
                            variation.sale_price = 300;//Convert.ToDecimal(item.ItemClass.OfferPrice);
                        }
                        variations.Add(variation);
                    }
                }
                else
                {
                    if (addColors)
                    {
                        foreach (var color in item.Colors)
                        {

                                WooCommerceNET.WooCommerce.v3.Variation variation = new WooCommerceNET.WooCommerce.v3.Variation();

                                WooCommerceNET.WooCommerce.v3.VariationAttribute colorAtt = new WooCommerceNET.WooCommerce.v3.VariationAttribute();
                                colorAtt.name = "Color";
                                colorAtt.option = color.ColorEnglishName;
                                variation.attributes = new List<VariationAttribute>();
                                variation.attributes.Add(colorAtt);
                                variation.manage_stock = true;
                                variation.stock_status = "instock";
                                variation.regular_price = 500;//Convert.ToDecimal(item.ItemClass.Price);
                                variation.sku = item.ItemClass.Code + color.ColorId.ToString();
                                variation.stock_quantity = 100;

                                if (item.ItemClass.OfferHasPriceOffer)
                                {
                                    variation.sale_price = 300;//Convert.ToDecimal(item.ItemClass.OfferPrice);
                                }
                                variations.Add(variation);
                        }
                    }
                }
            }

            return variations;
        }


        public ResultClass<ItemsDataClass> GetItemData(int LoggedUser, int ItemId)
        {
            ResultClass<ItemsDataClass> result = new ResultClass<ItemsDataClass>();
            try
            {
                using (SqlConnection conn = ConnectionClass.GetDataConnection())
                {
                    conn.Open();
                    SqlCommand cmd = new SqlCommand();
                    cmd.Connection = conn;
                    cmd.CommandType = System.Data.CommandType.StoredProcedure;
                    cmd.CommandText = "Admin_GetItemData";

                    List<SqlParameter> Params = new List<SqlParameter>()
               {
                  new SqlParameter("LoggedUser", "7")
               };

                    if (ItemId > 0)
                    {
                        cmd.Parameters.Add(new SqlParameter("ItemId", ItemId));
                    }

                    cmd.Parameters.AddRange(Params.ToArray());
                    SqlDataReader reader = cmd.ExecuteReader();
                    if (reader.HasRows)
                    {
                        var fieldNames = Enumerable.Range(0, reader.FieldCount).Select(i => reader.GetName(i)).ToArray();

                        ItemsDataClass itemsDataClass = new ItemsDataClass();

                        while (reader.Read())
                        {
                            itemsDataClass.ItemClass = new ItemClass().PopulateItemClass(fieldNames, reader);
                        }

                        //Companies
                        if (reader.NextResult())
                        {
                            if (reader.HasRows)
                            {
                                fieldNames = Enumerable.Range(0, reader.FieldCount).Select(i => reader.GetName(i)).ToArray();

                                List<ItemsCompanyClass> Companies = new List<ItemsCompanyClass>();
                                ItemsCompanyClass itemsCompany;

                                while (reader.Read())
                                {
                                    itemsCompany = new ItemsCompanyClass().PopulateItemsCompany(fieldNames, reader);

                                    Companies.Add(itemsCompany);
                                }
                                itemsDataClass.Companies = Companies;
                            }
                        }

                        //Governorates
                        if (reader.NextResult())
                        {
                            if (reader.HasRows)
                            {
                                fieldNames = Enumerable.Range(0, reader.FieldCount).Select(i => reader.GetName(i)).ToArray();

                                List<ItemsGovernorateClass> Governorates = new List<ItemsGovernorateClass>();
                                ItemsGovernorateClass itemsGovernorate;

                                while (reader.Read())
                                {
                                    itemsGovernorate = new ItemsGovernorateClass().PopulateItemsGovernorate(fieldNames, reader);

                                    Governorates.Add(itemsGovernorate);
                                }
                                itemsDataClass.Governorates = Governorates;
                            }
                        }

                        //Users Types
                        if (reader.NextResult())
                        {
                            if (reader.HasRows)
                            {
                                fieldNames = Enumerable.Range(0, reader.FieldCount).Select(i => reader.GetName(i)).ToArray();

                                List<ItemsUsersTypeClass> UsersTypes = new List<ItemsUsersTypeClass>();
                                ItemsUsersTypeClass itemsUserType;

                                while (reader.Read())
                                {
                                    itemsUserType = new ItemsUsersTypeClass().PopulateItemsUsersType(fieldNames, reader);

                                    UsersTypes.Add(itemsUserType);
                                }
                                itemsDataClass.UsersTypes = UsersTypes;
                            }
                        }

                        //Images
                        if (reader.NextResult())
                        {
                            if (reader.HasRows)
                            {
                                fieldNames = Enumerable.Range(0, reader.FieldCount).Select(i => reader.GetName(i)).ToArray();

                                List<ItemImageClass> Images = new List<ItemImageClass>();
                                ItemImageClass itemsImage;

                                while (reader.Read())
                                {
                                    itemsImage = new ItemImageClass().PopulateItemImage(fieldNames, reader);

                                    Images.Add(itemsImage);
                                }
                                itemsDataClass.Images = Images;
                            }
                        }

                        //Colors
                        if (reader.NextResult())
                        {
                            if (reader.HasRows)
                            {
                                fieldNames = Enumerable.Range(0, reader.FieldCount).Select(i => reader.GetName(i)).ToArray();

                                List<ItemColorClass> Colors = new List<ItemColorClass>();
                                ItemColorClass itemsColor;

                                while (reader.Read())
                                {
                                    itemsColor = new ItemColorClass().PopulateItemColor(fieldNames, reader);

                                    Colors.Add(itemsColor);
                                }
                                itemsDataClass.Colors = Colors;
                            }
                        }

                        //Sizes
                        if (reader.NextResult())
                        {
                            if (reader.HasRows)
                            {
                                fieldNames = Enumerable.Range(0, reader.FieldCount).Select(i => reader.GetName(i)).ToArray();

                                List<ItemSizeClass> Sizes = new List<ItemSizeClass>();
                                ItemSizeClass itemsSize;

                                while (reader.Read())
                                {
                                    itemsSize = new ItemSizeClass().PopulateItemSize(fieldNames, reader);

                                    Sizes.Add(itemsSize);
                                }
                                itemsDataClass.Sizes = Sizes;
                            }
                        }

                        //Prices
                        if (reader.NextResult())
                        {
                            if (reader.HasRows)
                            {
                                fieldNames = Enumerable.Range(0, reader.FieldCount).Select(i => reader.GetName(i)).ToArray();

                                List<ItemPriceClass> PricesList = new List<ItemPriceClass>();
                                ItemPriceClass itemPrice;
                                int order = 0;
                                while (reader.Read())
                                {
                                    order++;
                                    itemPrice = new ItemPriceClass().PopulateItemPrice(fieldNames, reader);
                                    itemPrice.Order = order;
                                    PricesList.Add(itemPrice);
                                }
                                itemsDataClass.Prices = PricesList;
                            }
                        }

                        //Config Prices
                        if (reader.NextResult())
                        {
                            if (reader.HasRows)
                            {
                                fieldNames = Enumerable.Range(0, reader.FieldCount).Select(i => reader.GetName(i)).ToArray();

                                List<ItemPriceClass> ConfigPricesList = new List<ItemPriceClass>();
                                ItemPriceClass itemConfigPrice;
                                int order = 0;
                                while (reader.Read())
                                {
                                    order++;
                                    itemConfigPrice = new ItemPriceClass().PopulateItemPrice(fieldNames, reader);
                                    itemConfigPrice.Order = order;
                                    ConfigPricesList.Add(itemConfigPrice);
                                }
                                itemsDataClass.ConfigPrices = ConfigPricesList;
                            }
                        }


                        //Countries
                        if (reader.NextResult())
                        {
                            if (reader.HasRows)
                            {
                                fieldNames = Enumerable.Range(0, reader.FieldCount).Select(i => reader.GetName(i)).ToArray();

                                List<ItemsCountryClass> CountriesList = new List<ItemsCountryClass>();
                                ItemsCountryClass itemCountry;

                                while (reader.Read())
                                {
                                    itemCountry = new ItemsCountryClass().PopulateItemsCountry(fieldNames, reader);

                                    CountriesList.Add(itemCountry);
                                }
                                itemsDataClass.Countries = CountriesList;
                            }
                        }


                        //new added
                        CategoriesWithMapClass categoriesWithMap = new CategoriesWithMapClass();
                        itemsDataClass.CategoriesMap = new CategoriesWithMapClass();

                        int totalCont = 0;

                        if (reader.NextResult())
                        {
                            if (reader.HasRows)
                            {
                                fieldNames = Enumerable.Range(0, reader.FieldCount).Select(i => reader.GetName(i)).ToArray();
                                reader.Read();
                                if (fieldNames.Contains("TotalCount"))
                                    if (!Convert.IsDBNull(reader["TotalCount"]))
                                        totalCont = Convert.ToInt32(reader["TotalCount"]);
                            }
                        }

                        if (reader.NextResult())
                        {
                            if (reader.HasRows)
                            {
                                fieldNames = Enumerable.Range(0, reader.FieldCount).Select(i => reader.GetName(i)).ToArray();
                                List<CategoryClass> Categories = new List<CategoryClass>();
                                CategoryClass category;
                                int order = 0;
                                while (reader.Read())
                                {
                                    order += 1;
                                    category = new CategoryClass().PopulateCategory(fieldNames, reader);
                                    category.Order = order;
                                    Categories.Add(category);
                                }
                                categoriesWithMap.Categories = Categories;
                            }
                        }

                        if (reader.NextResult())
                        {
                            if (reader.HasRows)
                            {
                                fieldNames = Enumerable.Range(0, reader.FieldCount).Select(i => reader.GetName(i)).ToArray();

                                List<CategoryMapClass> categoriesMap = new List<CategoryMapClass>();
                                CategoryMapClass map;
                                while (reader.Read())
                                {
                                    map = new CategoryMapClass().PopulateCategoryMap(fieldNames, reader);

                                    categoriesMap.Add(map);
                                }
                                categoriesWithMap.CategoriesMap = categoriesMap;
                            }
                        }

                        //BookingDay
                        if (reader.NextResult())
                        {
                            if (reader.HasRows)
                            {
                                fieldNames = Enumerable.Range(0, reader.FieldCount).Select(i => reader.GetName(i)).ToArray();

                                List<ItemBookingDayClass> BookingDayList = new List<ItemBookingDayClass>();
                                ItemBookingDayClass bookingDay;
                                int Order = 0;
                                while (reader.Read())
                                {
                                    Order++;
                                    bookingDay = new ItemBookingDayClass().PopulateItemBookingDay(fieldNames, reader);
                                    bookingDay.Order = Order;
                                    BookingDayList.Add(bookingDay);
                                }
                                itemsDataClass.BookingDays = BookingDayList;
                            }
                        }
                        //BookingDaysTimes
                        if (reader.NextResult())
                        {
                            if (reader.HasRows)
                            {
                                fieldNames = Enumerable.Range(0, reader.FieldCount).Select(i => reader.GetName(i)).ToArray();

                                //List<ItemBookingDayTimeClass> BookingDayList = new List<ItemBookingDayTimeClass>();
                                ItemBookingDayTimeClass bookingDaysTime;

                                int Order = 0;
                                while (reader.Read())
                                {
                                    bookingDaysTime = new ItemBookingDayTimeClass().PopulateItemBookingDayTime(fieldNames, reader);
                                    foreach (ItemBookingDayClass item in itemsDataClass.BookingDays)
                                    {
                                        if (item.Id == bookingDaysTime.ItemBookingDayId)
                                        {
                                            Order++;
                                            bookingDaysTime.Order = Order;
                                            item.ItemBookingDayTime.Add(bookingDaysTime);
                                        }
                                    }
                                    //BookingDayList.Add(bookingDays);
                                }
                                //itemsDataClass.BookingDays = BookingDayList;
                            }
                        }

                        itemsDataClass.HasSeries = false;
                        if (reader.NextResult())
                        {
                            //Series
                            if (reader.HasRows)
                            {
                                fieldNames = Enumerable.Range(0, reader.FieldCount).Select(i => reader.GetName(i)).ToArray();

                                List<ItemSeriesClass> seriesList = new List<ItemSeriesClass>();
                                ItemSeriesClass itemSeries;

                                int Order = 0;
                                while (reader.Read())
                                {
                                    itemSeries = new ItemSeriesClass().PopulateItemSeries(fieldNames, reader);
                                    Order++;
                                    itemSeries.Order = Order;
                                    seriesList.Add(itemSeries);
                                    if (itemSeries.Quantity > 0)
                                        itemsDataClass.HasSeries = true;
                                }
                                itemsDataClass.Series = seriesList;

                            }
                        }

                        if (reader.NextResult())
                        {
                            //MatchedItems
                            if (reader.HasRows)
                            {
                                fieldNames = Enumerable.Range(0, reader.FieldCount).Select(i => reader.GetName(i)).ToArray();

                                List<ItemClass> matchedItemsList = new List<ItemClass>();
                                ItemClass matchedItem;

                                int Order = 0;
                                while (reader.Read())
                                {
                                    matchedItem = new ItemClass().PopulateItemClass(fieldNames, reader);
                                    Order++;
                                    matchedItem.Order = Order;
                                    matchedItemsList.Add(matchedItem);
                                }
                                itemsDataClass.MatchedItems = matchedItemsList;

                            }
                        }

                        if (reader.NextResult())
                        {
                            //Serials
                            if (reader.HasRows)
                            {
                                fieldNames = Enumerable.Range(0, reader.FieldCount).Select(i => reader.GetName(i)).ToArray();

                                List<ItemSerialClass> itemSerialsList = new List<ItemSerialClass>();
                                ItemSerialClass itemSerial;

                                int Order = 0;
                                while (reader.Read())
                                {
                                    itemSerial = new ItemSerialClass().PopulateItemSerial(fieldNames, reader);
                                    Order++;
                                    itemSerial.Order = Order;
                                    itemSerialsList.Add(itemSerial);
                                }
                                itemsDataClass.Serials = itemSerialsList;

                            }
                        }




                        result.Result = itemsDataClass;
                        result.Code = Errors.Success;
                        result.Message = "";
                        return result;
                    }
                    else
                    {
                        result.Code = Errors.Success;
                        result.Message = "";
                        result.Result = null;
                        return result;
                    }
                }
            }
            catch (Exception e)
            {
                int code;
                if (Int32.TryParse(e.Message, out code))
                {
                    result.Code = code;
                    result.Message = Errors.GetErrorMessage(code);
                }
                else
                {
                    result.Code = Errors.UnknownError;
                    result.Message = Errors.GetErrorMessage(result.Code);
                    Errors.LogError(0, e.Message, e.StackTrace, "1.0.3", "API", "GetItemData", e.Source, "");
                }
                result.Result = null;
                return result;
            }

        }

    }
}