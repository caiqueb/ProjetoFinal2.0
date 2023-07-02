using ProjetoFinal2._0.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ProjetoFinal2._0.Classes
{
    public class DBHelper
    {

        public static Response SaveChanges(ProjetoContext db)
        {
            try
            {
                db.SaveChanges();
                return new Response
                {
                    Succeeded = true
                };
            }
            catch (Exception ex)
            {
                var response = new Response
                {

                    Succeeded = false
                };

                if (ex.InnerException != null && ex.InnerException.InnerException != null && ex.InnerException.InnerException.Message.Contains("_Index"))
                {
                    response.Message = "O registro está duplicado";
                }
                else if (ex.InnerException != null && ex.InnerException.InnerException != null && ex.InnerException.InnerException.Message.Contains("REFERENCE"))
                {
                    response.Message = "Não é possível remover o registro, pois existem dados relacionados a ele";
                }
                else
                {
                    response.Message = "Não foi possível salvar os dados";
                }

                return response;
            }
        }

        public static int GetState(string description, ProjetoContext db)
        {
            var state = db.States.Where(s => s.Description == description).FirstOrDefault();
            if (state == null)
            {
                state = new State
                {
                    Description = description
                };

                db.States.Add(state);
                db.SaveChanges();
            }

            return state.StateId;
        }
    }
}