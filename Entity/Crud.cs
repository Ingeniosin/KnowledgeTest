namespace PruebaConocimiento.Entity {
    public interface Crud<T> {

        T create(T obj);

        T delete(T obj);

        T update(T obj);

    }
}