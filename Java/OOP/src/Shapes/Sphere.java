package Shapes;

import java.util.ArrayList;

import Vertices.Vertex3D;

public class Sphere extends SpaceShape {

	private double radius;

	public Sphere(Vertex3D center, double radius) {
		this.vertices = new ArrayList<Vertex3D>();
		this.vertices.add(center);
		this.radius = radius;
	}

	@Override
	public double getArea() {
		return 4 * Math.PI * this.radius * this.radius;
	}

	@Override
	public double getVolume() {
		return 4 / 3 * Math.PI * this.radius * this.radius * this.radius;
	}

}
