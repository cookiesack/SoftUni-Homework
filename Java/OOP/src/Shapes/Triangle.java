package Shapes;

import java.util.ArrayList;
import java.util.List;

import Vertices.*;

public class Triangle extends PlaneShape {
	public Triangle(List<Vertex2D> vertices) {
		this.vertices = new ArrayList<Vertex2D>(vertices);
	}

	private ArrayList<Double> getSides() {
		ArrayList<Double> sides = new ArrayList<Double>();
		for (int i = 0; i < 3; i++) {
			for (int j = i + 1; j < 3; j++) {
				Vertex2D A = (Vertex2D) this.vertices.get(i);
				Vertex2D B = (Vertex2D) this.vertices.get(j);
				sides.add(Math.sqrt(Math.pow(A.getX() - B.getX(), 2) + Math.pow(A.getY() - B.getY(), 2)));
			}
		}
		return sides;
	}

	@Override
	public double getPerimeter() {
		double perimeter = 0;
		for (Double side : this.getSides()) {
			perimeter += side;
		}
		return perimeter;
	}

	@Override
	public double getArea() {
		double area = 0;
		double halfPerimeter = this.getPerimeter() / 2;
		ArrayList<Double> sides = this.getSides();
		area = Math.sqrt(halfPerimeter * (halfPerimeter - sides.get(0)) * (halfPerimeter - sides.get(1))
				* (halfPerimeter - sides.get(2)));
		return area;
	}
}
