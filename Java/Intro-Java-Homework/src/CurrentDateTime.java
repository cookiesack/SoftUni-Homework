import java.util.Date;
import java.text.DateFormat;
import java.text.SimpleDateFormat;

public class CurrentDateTime {
	public static void Print() {
		DateFormat dateFormat = new SimpleDateFormat("yyyy/MM/dd HH:mm:ss");
		Date date = new Date();
		System.out.println(dateFormat.format(date));
	}
}
