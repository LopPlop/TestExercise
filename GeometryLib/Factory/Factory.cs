using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GeometryLib.Geometry;

namespace GeometryLib.Factory
{
    // Абстрактный класс, служащий для реализации фабричного паттерна
    public abstract class Factory
    {
        // Свойство для записи в него строки
        protected string Str { get; set; }

        public Factory(string str) => this.Str = str;

        // Абстрактный метод, служащий для производства объектов
        public abstract IGeometricObject Create();
    }
}
