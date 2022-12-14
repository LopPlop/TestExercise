namespace GeometryLib.Geometry
{
    // Интерфейс геометрических фигур
    public interface IGeometricObject
    {
        // Метод, который вызывает методы нахождения пересения с различными геометрическими объектами
        void Intersect(IGeometricObject obj);
    }
}