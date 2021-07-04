using System;
using System.Collections.Generic;

namespace PruebaConocimiento.Entity {

    public class UsersCrudImlp : Crud<User> {

        public static Dictionary<string, User> users = new Dictionary<string, User>();

        public User create(User obj) {

            if(users.ContainsKey(obj.identifier)) 
                throw new Exception(new Error("¡Este usuario ya existe!", "304").toJson());

            //Aqui iria el guardado en db 
            
            users.Add(obj.identifier, obj);
            return obj;
        }

        public User delete(User obj) {
            return null;
        }

        public User update(User obj) {
            return null;
        }
    


    }
}