using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace EFModel
{
    public class Get
    {
        public List<Role> AllRoles()
        {
            List<Role> Result = new List<Role>();
            
            using (var db = new PAEntities())
            {
                Result = (from x in db.Roles
                                  orderby x.ID
                                  select x).ToList<Role>();

            }
            return Result;
        }

        public List<Document> AllDocuments()
        {
            List<Document> Result = new List<Document>();

            using (var db = new PAEntities())
            {
                Result = (from x in db.Documents
                          orderby x.ID
                          select x).ToList<Document>();

            }
            return Result;
        }

        public List<Task> AllTasks()
        {
            List<Task> Result = new List<Task>();

            using (var db = new PAEntities())
            {
                Result = (from x in db.Tasks
                          orderby x.ID
                          select x).ToList<Task>();

            }
            return Result;
        }

        public List<Store> AllStores()
        {
            List<Store> Result = new List<Store>();

            using (var db = new PAEntities())
            {
                Result = (from x in db.Stores
                          orderby x.ID
                          select x).ToList<Store>();

            }
            return Result;
        }

        public List<Condition> AllConditions()
        {
            List<Condition> Result = new List<Condition>();

            using (var db = new PAEntities())
            {
                Result = (from x in db.Conditions
                          orderby x.ID
                          select x).ToList<Condition>();

            }
            return Result;
        }

        public List<Ingredient> AllIngredients()
        {
            List<Ingredient> Result = new List<Ingredient>();

            using (var db = new PAEntities())
            {
                Result = (from x in db.Ingredients
                          orderby x.ID
                          select x).ToList<Ingredient>();

            }
            return Result;
        }


    }
}
