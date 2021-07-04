using System.Text.Json;
namespace PruebaConocimiento.Entity {
    public class Error {
        public string errorMessage {get;}
        public string errorCode {get;}
        
        public Error(string errorMessage, string errorCode) {
            this.errorMessage = errorMessage;
            this.errorCode = errorCode;
        }

        public Error(string errorMessage) {
            this.errorMessage = errorMessage;
        }

        public string toJson() {
                return JsonSerializer.Serialize(this);
        }

    }
}
