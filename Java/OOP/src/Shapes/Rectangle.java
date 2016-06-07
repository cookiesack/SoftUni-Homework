package Shapes;

import java.util.ArrayList;

import Vertices.Vertex2D;

public class Rectangle extends PlaneShape {

	private double width;
	private double height;

	public Rectangle(Vertex2D vertex, double width, double height) {
		this.vertices = new ArrayList<Vertex2D>();
		this.vertices.add(vertex);
		this.width = width;
		this.height = height;
	}

	@Override
	public double getPerimeter() {
		return 2 * (this.width + this.height);
	}

	@Override
	public double getArea() {
		return this.width * this.height;
	}

}
