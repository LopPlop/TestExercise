namespace GeometryLib.Geometry
{
    // Интерфейс геометрических фигур
    public interface IGeometricObject
    {
        // Метод, который выводи информацию об объекте в консоль
        void Draw();
        // Метод, который вызывает методы нахождения пересения с различными геометрическими объектами
        void Intersect(IGeometricObject obj);
    }
}