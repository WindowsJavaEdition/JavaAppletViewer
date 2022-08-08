import java.applet.*;
import java.awt.*;
import java.awt.event.*;

public class ButtonExample extends Applet implements ActionListener {
	public void init() {
		button1 = new Button("Hi! I'm an button!");
		add(button1);
		button1.addActionListener(this);
	}

	public void actionPerformed(ActionEvent e) {
		if (e.getSource() == button1) 
			System.out.println("I was pressed!");
	}

	Button button1;
}