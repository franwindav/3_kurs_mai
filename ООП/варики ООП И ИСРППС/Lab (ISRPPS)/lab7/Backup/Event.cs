using System;

// ������� ��� ������� -������ �� ����������� + ��������� ��� ������������-
//(��� �������� + ������ ����������)
// 
delegate void KeyHandler(object source, KeyEventArgs arg);

//  ��������� ��� ������������  
class KeyEventArgs : EventArgs 
{
	public char ch;
}

// ����� �������, ���������� � �������� ������� �� ����������
class KeyEvent 
{
//  �������
	public event KeyHandler KeyPress;

//  ��������� �������, ���������� � �������� �������
	public void OnKeyPress(char key) 
	{
		KeyEventArgs k = new KeyEventArgs();
		if (KeyPress != null) 
		{
//  ������������ ��������� ��� ������������
			k.ch = key;
			KeyPress(this,k);
		}
	}
}


//  �����, ������� ��������� ����������� � ������� ������� (������� ������� ) 
class ProcessKey 
{
//  ���������� �������
	public void keyhandler (object source, KeyEventArgs arg) 
	{
		Console.WriteLine("�������� ��������� � ������ �������: " + arg.ch);
	}
}

//  �����, ������� ��������� ����������� � ������� ������� (������� ������� )
class CountKey 
{
	public int count = 0;
//  ���������� �������
	public void keyhandler (object source, KeyEventArgs arg) 
	{
		count++;
	}
}

class KeyEventDemo 
{
	public static void Main() 
	{
		// �������� �������  ������ �������
		KeyEvent kevt = new KeyEvent();
		//  �������� ������� ������, ���������� ������� 
		ProcessKey  pk = new ProcessKey ();
		//  �������� ������� ������, ���������� �������
		CountKey  ck = new CountKey();
		char ch;
		//  ������������ ������ ������������ ��� �������
		kevt.KeyPress += new KeyHandler(pk.keyhandler);
		kevt.KeyPress += new KeyHandler(ck.keyhandler);

		Console.WriteLine("������� ��������� ��������." + "��� �������� ������� �����.");

		do 
		{
		//  ������� �������
			ch = (char) Console.Read();
		//  ��������� �������
			kevt.OnKeyPress(ch);
		} while(ch!='.');
			Console.WriteLine("���� ������ " + ck.count +  "������");
}
}






