package Shapes;

import java.util.ArrayList;

import Interfaces.*;
import Vertices.*;

public abstract class PlaneShape extends Shape implements PerimeterMeasurable, AreaMeasurable {
	protected ArrayList<Vertex2D> vertices = new ArrayList<Vertex2D>();

	public PlaneShape() {
		this.vertices = new ArrayList<Vertex2D>();
	}

	public ArrayList<Vertex2D> getVertices() {
		return this.vertices;
	}

	@Override
	public String toString() {
		StringBuilder sb = new StringBuilder();
		sb.append(this.getClass() + "\n");
		for (int i = 0; i < vertices.size(); i++) {
			sb.append(vertices.get(i).getX() + ", " + vertices.get(i).getY() + "\n");
		}
		sb.append(this.getPerimeter() + "\n");
		sb.append(this.getArea() + "\n");
		return sb.toString();
	}
}
