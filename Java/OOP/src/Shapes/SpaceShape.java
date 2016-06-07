package Shapes;

import java.util.ArrayList;

import Interfaces.*;
import Vertices.*;

public abstract class SpaceShape extends Shape implements AreaMeasurable, VolumeMeasurable {
	protected ArrayList<Vertex3D> vertices = new ArrayList<Vertex3D>();

	public SpaceShape() {
		this.vertices = new ArrayList<Vertex3D>();
	}

	public ArrayList<Vertex3D> getVertices() {
		return this.vertices;
	}

	@Override
	public String toString() {
		StringBuilder sb = new StringBuilder();
		sb.append(this.getClass() + "\n");
		for (int i = 0; i < vertices.size(); i++) {
			sb.append(vertices.get(i).getX() + ", " + vertices.get(i).getY() + "\n");
		}
		sb.append(this.getArea() + "\n");
		sb.append(this.getVolume() + "\n");
		return sb.toString();
	}
}
