using System;

abstract class Shape
{
    protected string _color;
    
    public Shape(string color) {
        _color = color; //atributo = parametro
    }

    public abstract double Area();

    public void DisplayColor()
    {
        Console.WriteLine("This shape" + _color +".");
    }

}

interface IDrawable
{
    void Draw();
}

class Circle : Shape, IDrawable //extends and inplements
{
    private double _radius;

    public Circle(string color, double radius) : base(color) //super clase padre
    {
        _radius = radius;
    }

    public override double Area() //override to say im doing specific implementaton
    {
        return Math.PI*_radius*_radius;
    }

    public void Draw()
    {
        Console.WriteLine("Drawing a Circle");  
    }
}
