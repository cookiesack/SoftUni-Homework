package Shapes;

import java.util.List;

import Vertices.*;

public abstract class Shape {
	protected List<? extends Vertex> vertices;

	@Override
	public String toString() {
		StringBuilder sb = new StringBuilder();
		sb.append(this.getClass());
		for (int i = 0; i < vertices.size(); i++) {
			sb.append(vertices.get(i).getX() + ", " + vertices.get(i).getY());
		}
		return sb.toString();
	}
}
