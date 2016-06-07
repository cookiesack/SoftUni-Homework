package Shapes;

import java.util.ArrayList;

import Vertices.Vertex2D;

public class Circle extends PlaneShape {

	private double radius;

	public Circle(Vertex2D vertex, double radius) {
		this.vertices = new ArrayList<Vertex2D>();
		this.vertices.add(vertex);
		this.radius = radius;
	}

	@Override
	public double getPerimeter() {
		return 2 * Math.PI * this.radius;
	}

	@Override
	public double getArea() {
		return Math.PI * this.radius * this.radius;
	}

}
