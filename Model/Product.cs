using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;

namespace Model
{
    public class Product
    {
        #region Properties

        public Core.SQL.Functions.SQLDataType ID { get; set; }
        public Core.SQL.Functions.SQLDataType UPI { get; set; }
        public Core.SQL.Functions.SQLDataType Name { get; set; }
        public Core.SQL.Functions.SQLDataType Image { get; set; }
        public Core.SQL.Functions.SQLDataType Description { get; set; }
        public Core.SQL.Functions.SQLDataType Recommended { get; set; }
        public Core.SQL.Functions.SQLDataType ScheduleID { get; set; }
        public Core.SQL.Functions.SQLDataType Approved { get; set; }
        public Core.SQL.Functions.SQLDataType PrivateLabelUPI { get; set; }
        public Core.SQL.Functions.SQLDataType Price { get; set; }
        public Core.SQL.Functions.SQLDataType RecommendedPrice { get; set; }
        public Core.SQL.Functions.SQLDataType InStoreOnly { get; set; }
        public Core.SQL.Functions.SQLDataType Limit { get; set; }
        public Core.SQL.Functions.SQLDataType ShelfTalker { get; set; }
        public Core.SQL.Functions.SQLDataType BrandID { get; set; }
        public Core.SQL.Functions.SQLDataType Thumbnail { get; set; }
        public Core.SQL.Functions.SQLDataType MeasureID { get; set; }
        public Core.SQL.Functions.SQLDataType MeasureValue { get; set; }
        public Core.SQL.Functions.SQLDataType IngredientID { get; set; }
        public Core.SQL.Functions.SQLDataType Rank { get; set; }
        public Core.SQL.Functions.SQLDataType CoreProduct { get; set; }
        public Core.SQL.Functions.SQLDataType Comment { get; set; }
        public Core.SQL.Functions.SQLDataType CurrentUsername { get; set; }
        public Core.SQL.Functions.SQLDataType CustomString1 { get; set; }
        public Core.SQL.Functions.SQLDataType CustomString2 { get; set; }
        public Core.SQL.Functions.SQLDataType CustomString3 { get; set; }
        public Core.SQL.Functions.SQLDataType CustomString4 { get; set; }

        #endregion

        public Product()
        {
            this.ID = new Core.SQL.Functions.SQLDataType();
            this.UPI = new Core.SQL.Functions.SQLDataType();
            this.Name = new Core.SQL.Functions.SQLDataType();
            this.Image = new Core.SQL.Functions.SQLDataType();
            this.Description = new Core.SQL.Functions.SQLDataType();
            this.Recommended = new Core.SQL.Functions.SQLDataType();
            this.ScheduleID = new Core.SQL.Functions.SQLDataType();
            this.Approved = new Core.SQL.Functions.SQLDataType();
            this.PrivateLabelUPI = new Core.SQL.Functions.SQLDataType();
            this.Price = new Core.SQL.Functions.SQLDataType();
            this.RecommendedPrice = new Core.SQL.Functions.SQLDataType();
            this.InStoreOnly = new Core.SQL.Functions.SQLDataType();
            this.Limit = new Core.SQL.Functions.SQLDataType();
            this.ShelfTalker = new Core.SQL.Functions.SQLDataType();
            this.BrandID = new Core.SQL.Functions.SQLDataType();
            this.Thumbnail = new Core.SQL.Functions.SQLDataType();
            this.MeasureID = new Core.SQL.Functions.SQLDataType();
            this.MeasureValue = new Core.SQL.Functions.SQLDataType();
            this.IngredientID = new Core.SQL.Functions.SQLDataType();
            this.Rank = new Core.SQL.Functions.SQLDataType();
            this.CoreProduct = new Core.SQL.Functions.SQLDataType();
            this.Comment = new Core.SQL.Functions.SQLDataType();
            this.CurrentUsername = new Core.SQL.Functions.SQLDataType();
            this.CustomString1 = new Core.SQL.Functions.SQLDataType();
            this.CustomString2 = new Core.SQL.Functions.SQLDataType();
            this.CustomString3 = new Core.SQL.Functions.SQLDataType();
            this.CustomString4 = new Core.SQL.Functions.SQLDataType();
        }

        public Product Load(int ID, string ConnectionString)
        {
            DataSet Data = new System.Data.DataSet("Product");
            StringBuilder Query = new StringBuilder();

            Query.Append("SELECT ");
            Query.Append("ISNULL(Approved,'') AS Approved,");
            Query.Append("ISNULL(BrandID,0) AS BrandID,");
            Query.Append("ISNULL(Comment,'') AS Comment,");
            Query.Append("ISNULL(CurrentUsername,'') AS CurrentUsername,");
            Query.Append("ISNULL(CustomString1,'') AS CustomString1,");
            Query.Append("ISNULL(CustomString2,'') AS CustomString2,");
            Query.Append("ISNULL(CustomString3,'') AS CustomString3,");
            Query.Append("ISNULL(CustomString4,'') AS CustomString4,");
            Query.Append("ISNULL(CoreProduct,0) AS CoreProduct,");
            Query.Append("ISNULL(Description,'') AS Description,");
            Query.Append("ISNULL(ID,0) AS ID,");
            Query.Append("ISNULL(Image,'') AS Image,");
            Query.Append("ISNULL(IngredientID,0) AS IngredientID,");
            Query.Append("ISNULL(InStoreOnly,0) AS InStoreOnly,");
            Query.Append("ISNULL(Limit,0) AS Limit,");
            Query.Append("ISNULL(MeasureID,0) AS MeasureID,");
            Query.Append("ISNULL(MeasureValue,0) AS MeasureValue,");
            Query.Append("ISNULL(Name,'') AS Name,");
            Query.Append("ISNULL(Price,0.0) AS Price,");
            Query.Append("ISNULL(PrivateLabelUPI,0) AS PrivateLabelUPI,");
            Query.Append("ISNULL(Rank,0) AS Rank,");
            Query.Append("ISNULL(Recommended,0) AS Recommended,");
            Query.Append("ISNULL(RecommendedPrice,0.0) AS RecommendedPrice,");
            Query.Append("ISNULL(ScheduleID,0) AS ScheduleID,");
            Query.Append("ISNULL(ShelfTalker,0) AS ShelfTalker,");
            Query.Append("ISNULL(Thumbnail,'') AS Thumbnail,");
            Query.Append("ISNULL(UPI,0) AS UPI ");

            Query.Append("FROM Product WHERE Product.ID = " + ID);

            Data = Core.SQL.Functions.Execute(Query.ToString(), ConnectionString);

            if (Data.Tables[0] != null)
            {
                if (Data.Tables[0].Rows.Count == 1)
                {
                    DataRow Row = Data.Tables[0].Rows[0];
                    if (!Row.IsNull("Approved")) this.Approved.Set((bool)Data.Tables[0].Rows[0]["Approved"]);
                    if (!Row.IsNull("BrandID")) this.BrandID.Set((int)Data.Tables[0].Rows[0]["BrandID"]);
                    if (!Row.IsNull("Comment")) this.Comment.Set((string)Data.Tables[0].Rows[0]["Comment"]);
                    if (!Row.IsNull("CurrentUsername")) this.CurrentUsername.Set((string)Data.Tables[0].Rows[0]["CurrentUsername"]);
                    if (!Row.IsNull("CustomString1")) this.CustomString1.Set((string)Data.Tables[0].Rows[0]["CustomString1"]);
                    if (!Row.IsNull("CustomString2")) this.CustomString2.Set((string)Data.Tables[0].Rows[0]["CustomString2"]);
                    if (!Row.IsNull("CustomString3")) this.CustomString3.Set((string)Data.Tables[0].Rows[0]["CustomString3"]);
                    if (!Row.IsNull("CustomString4")) this.CustomString4.Set((string)Data.Tables[0].Rows[0]["CustomString4"]);
                    if (!Row.IsNull("CoreProduct")) this.CoreProduct.Set((bool)Data.Tables[0].Rows[0]["CoreProduct"]);
                    if (!Row.IsNull("Description")) this.Description.Set((string)Data.Tables[0].Rows[0]["Description"]);
                    if (!Row.IsNull("ID")) this.ID.Set((int)Data.Tables[0].Rows[0]["ID"]);
                    if (!Row.IsNull("Image")) this.Image.Set((string)Data.Tables[0].Rows[0]["Image"]);
                    if (!Row.IsNull("IngredientID")) this.IngredientID.Set((int)Data.Tables[0].Rows[0]["IngredientID"]);
                    if (!Row.IsNull("InStoreOnly")) this.InStoreOnly.Set((bool)Data.Tables[0].Rows[0]["InStoreOnly"]);
                    if (!Row.IsNull("Limit")) this.Limit.Set((int)Data.Tables[0].Rows[0]["Limit"]);
                    if (!Row.IsNull("MeasureID")) this.MeasureID.Set((int)Data.Tables[0].Rows[0]["MeasureID"]);
                    if (!Row.IsNull("MeasureValue")) this.MeasureValue.Set((float)Data.Tables[0].Rows[0]["MeasureValue"]);
                    if (!Row.IsNull("Name")) this.Name.Set((string)Data.Tables[0].Rows[0]["Name"]);
                    if (!Row.IsNull("Price")) this.Price.Set((decimal)Data.Tables[0].Rows[0]["Price"]);
                    if (!Row.IsNull("PrivateLabelUPI")) this.PrivateLabelUPI.Set((int)Data.Tables[0].Rows[0]["PrivateLabelUPI"]);
                    if (!Row.IsNull("Rank")) this.Rank.Set((int)Data.Tables[0].Rows[0]["Rank"]);
                    if (!Row.IsNull("Recommended")) this.Recommended.Set((bool)Data.Tables[0].Rows[0]["Recommended"]);
                    if (!Row.IsNull("RecommendedPrice")) this.RecommendedPrice.Set((decimal)Data.Tables[0].Rows[0]["RecommendedPrice"]);
                    if (!Row.IsNull("ScheduleID")) this.ScheduleID.Set((int)Data.Tables[0].Rows[0]["ScheduleID"]);
                    if (!Row.IsNull("ShelfTalker")) this.ShelfTalker.Set((bool)Data.Tables[0].Rows[0]["ShelfTalker"]);
                    if (!Row.IsNull("Thumbnail")) this.Thumbnail.Set((string)Data.Tables[0].Rows[0]["Thumbnail"]);
                    if (!Row.IsNull("UPI")) this.UPI.Set((int)Data.Tables[0].Rows[0]["UPI"]);
                }
            }
            return this;
        }

        public bool Save(string ConnectionString)
        {
            bool Result = false;

            StringBuilder Query = new StringBuilder();

            if ((int)ID.Get() == 0)
            {
                // Perform INSERT
            }
            else
            {
                // Perform UPDATE
                Query.Append("UPDATE Product SET ");
                Query.Append("Approved = " + Core.SQL.Functions.SQLBoolean((bool)this.Approved.Get()) + ",");
                if (this.BrandID.Get() != null)
                    Query.Append("BrandID = " + Core.SQL.Functions.SQLInteger((int)this.BrandID.Get()) + ",");
                Query.Append("Comment = '" + Core.SQL.Functions.SQLString((string)this.Comment.Get()) + "', ");
                Query.Append("CurrentUsername = '" + Core.SQL.Functions.SQLString((string)this.CurrentUsername.Get()) + "', ");
                Query.Append("CustomString1 = '" + Core.SQL.Functions.SQLString((string)this.CustomString1.Get()) + "', ");
                Query.Append("CustomString2 = '" + Core.SQL.Functions.SQLString((string)this.CustomString2.Get()) + "', ");
                Query.Append("CustomString3 = '" + Core.SQL.Functions.SQLString((string)this.CustomString3.Get()) + "', ");
                Query.Append("CustomString4 = '" + Core.SQL.Functions.SQLString((string)this.CustomString4.Get()) + "', ");
                Query.Append("CoreProduct = " + Core.SQL.Functions.SQLBoolean((bool)this.CoreProduct.Get()) + ",");
                Query.Append("Description = '" + Core.SQL.Functions.SQLString((string)this.Description.Get()) + "', ");
                Query.Append("Image = '" + Core.SQL.Functions.SQLString((string)this.Image.Get()) + "', ");
                if (this.IngredientID.Get() != null)
                    Query.Append("IngredientID = " + Core.SQL.Functions.SQLInteger((int)this.IngredientID.Get()) + ",");
                Query.Append("InStoreOnly = " + Core.SQL.Functions.SQLBoolean((bool)this.InStoreOnly.Get()) + ",");
                if (this.Limit.Get() != null)
                    Query.Append("Limit = " + Core.SQL.Functions.SQLInteger((int)this.Limit.Get()) + ",");
                if (this.MeasureID.Get() != null)
                    Query.Append("MeasureID = " + Core.SQL.Functions.SQLInteger((int)this.MeasureID.Get()) + ",");
                Query.Append("MeasureValue = " + Core.SQL.Functions.SQLFloat((float)this.MeasureValue.Get()) + ",");
                Query.Append("Name = '" + Core.SQL.Functions.SQLString((string)this.Name.Get()) + "', ");
                Query.Append("Price = " + Core.SQL.Functions.SQLDecimal((decimal)this.Price.Get()) + ",");
                if (this.PrivateLabelUPI.Get() != null)
                    Query.Append("PrivateLabelUPI = " + Core.SQL.Functions.SQLInteger((int)this.PrivateLabelUPI.Get()) + ",");
                if (this.Rank.Get() != null)
                    Query.Append("Rank = " + Core.SQL.Functions.SQLInteger((int)this.Rank.Get()) + ",");
                Query.Append("Recommended = " + Core.SQL.Functions.SQLBoolean((bool)this.Recommended.Get()) + ",");
                Query.Append("RecommendedPrice = " + Core.SQL.Functions.SQLDecimal((decimal)this.RecommendedPrice.Get()) + ",");
                if (this.ScheduleID.Get() != null)
                    Query.Append("ScheduleID = " + Core.SQL.Functions.SQLInteger((int)this.ScheduleID.Get()) + ",");
                Query.Append("ShelfTalker = " + Core.SQL.Functions.SQLBoolean((bool)this.ShelfTalker.Get()) + ",");
                Query.Append("Thumbnail = '" + Core.SQL.Functions.SQLString((string)this.Thumbnail.Get()) + "', ");
                if (this.UPI.Get() != null)
                    Query.Append("UPI = " + Core.SQL.Functions.SQLInteger((int)this.UPI.Get()) + " ");

                Query.Append("WHERE ID = " + this.ID);

                Core.SQL.Functions.ExecuteNonQuery(Query.ToString(), ConnectionString);

                
            }

            return Result;
        }

    }
}
