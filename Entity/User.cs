using System;
using System.Collections.Generic;
using System.Text.Json;
using System.Text.RegularExpressions;
using System.Linq;

namespace PruebaConocimiento.Entity {
    
    public class User {

        public String identifier { get; set; }
        public String name { get; set; }
        public String lastname { get; set; }
        public List<String> phones { get; set; }

       
        public User(String identifier, String name, String lastname, List<String> phones) {
            if(identifier is null || name is null || lastname is null || phones is null || phones is not null && phones.Count == 0) 
                throw new Exception(new Error("¡Una o mas entradas son nulas!").toJson());
            
            if(!Regex.IsMatch(identifier.Trim(), "^[0-9]{4,12}$") || !Regex.IsMatch(name.Trim(), "^[a-zA-zñÑ ]{4,16}$") || !Regex.IsMatch(lastname.Trim(), "^[a-zA-zñÑ ]{4,16}$") || phones.Any(e => !Regex.IsMatch(e, "^[0-9]{10}$"))){
                throw new Exception(new Error("¡Las entradas son invalidas!", "406").toJson());
            }

            this.identifier = identifier.Trim();
            this.name = name.Trim();
            this.lastname = lastname.Trim();
            this.phones = phones;
        }

         public User(String identifier, String name, String lastname, String phones) : this(identifier, name, lastname, phones is null ? (List<String>) null : new List<String>(phones.Replace(" ", "").Split(","))) {
        
        }

        public String toJson() {
            return JsonSerializer.Serialize(this);
        }
        

    }

}