package Vertices;

public class Vertex3D extends Vertex2D {
	private double z;

	public Vertex3D(double x, double y, double z) {
		super(x, y);
		this.z = z;
	}

	public double getZ() {
		return this.z;
	}

	public void setZ(double z) {
		this.z = z;
	}
}
