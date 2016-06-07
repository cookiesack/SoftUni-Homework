package Shapes;

import java.util.ArrayList;

import Vertices.Vertex3D;

public class Cuboid extends SpaceShape {

	private double width;
	private double height;
	private double depth;

	public Cuboid(Vertex3D vertex, double width, double height, double depth) {
		this.vertices = new ArrayList<Vertex3D>();
		this.vertices.add(vertex);
		this.width = width;
		this.height = height;
		this.depth = depth;
	}

	@Override
	public double getArea() {
		return 2 * (this.width * this.height + this.width * this.depth + this.height * this.depth);
	}

	@Override
	public double getVolume() {
		return this.width * this.height * this.depth;
	}

}
