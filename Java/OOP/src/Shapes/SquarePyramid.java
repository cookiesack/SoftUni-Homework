package Shapes;

import java.util.ArrayList;

import Vertices.*;

public class SquarePyramid extends SpaceShape {

	private double baseWidth;
	private double height;

	public SquarePyramid(Vertex3D baseCenter, double baseWidth, double height) {
		this.vertices = new ArrayList<Vertex3D>();
		this.vertices.add(baseCenter);
		this.baseWidth = baseWidth;
		this.height = height;
	}

	@Override
	public double getArea() {
		return this.baseWidth * this.baseWidth
				+ 2 * this.baseWidth * Math.sqrt(this.baseWidth * this.baseWidth / 4 + this.height * this.height);
	}

	@Override
	public double getVolume() {
		return this.baseWidth * this.baseWidth * this.height / 3;
	}
}
