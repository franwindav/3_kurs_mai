using System;

// ������� ��� ������� -������ �� ����������� + ��������� ��� ������������-
//(��� �������� + ������ ����������)
// 
delegate void KeyHandler(object source, KeyEventArgs arg);

//  ��������� ��� ������������  
class KeyEventArgs
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
			KeyPress(this, k);
		}
	}
}

abstract class ProcessKey
{
    protected ProcessKey successor;
    public void SetSuccessor(ProcessKey successor)
    {
        this.successor = successor;
    }

    public abstract void keyhandler(object source, KeyEventArgs arg);
}

class ConcreteProcessKey1 : ProcessKey
{
    public override void keyhandler(object source, KeyEventArgs arg)
    {
        if (arg.ch >= 'a' && arg.ch <= 'z')
        {
            Console.WriteLine("�������� ��������� � ������� �������: " + arg.ch);
            Console.WriteLine("{0} handled request {1}", this.GetType().Name, arg.ch);
        }
        else if (successor != null)
        {
           successor.keyhandler( source, arg);
        }
    }
}

class ConcreteProcessKey2 : ProcessKey
{
    public override void keyhandler(object source, KeyEventArgs arg)
    {
        if (arg.ch >= '�' && arg.ch <= '�')
        {
            Console.WriteLine("�������� ��������� � ������� �������: " + arg.ch);
            Console.WriteLine("{0} handled request {1}",
            this.GetType().Name, arg.ch);
        }
        else if (successor != null)
        {
            successor.keyhandler(source, arg);
        }
    }
}

class ConcreteProcessKey3 : ProcessKey
{
    public override void keyhandler(object source, KeyEventArgs arg)
    {
        if (arg.ch >= '0' && arg.ch <= '9')
        {
            Console.WriteLine("�������� ��������� � ������� �������: " + arg.ch);
            Console.WriteLine("{0} handled request {1}",
            this.GetType().Name, arg.ch);
        }
        else if (successor != null)
        {
           successor.keyhandler(source, arg);
        }
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
        ProcessKey h1 = new  ConcreteProcessKey1();
        ProcessKey h2 = new  ConcreteProcessKey2();
        ProcessKey h3 = new  ConcreteProcessKey3();
       
     h1.SetSuccessor(h2);
     h2.SetSuccessor(h3);

		//  �������� ������� ������, ���������� �������
	 CountKey  ck = new CountKey();

		char ch;

		//  ������������ ������ ������������ ��� �������
		kevt.KeyPress += new KeyHandler(h1.keyhandler);
		kevt.KeyPress += new KeyHandler(ck.keyhandler);

		Console.WriteLine("������� ��������� ��������." + "  ������� ����� - �����");

		do 
		{
		//  ������� �������
			ch = (char) Console.Read();
		//  ��������� �������
			kevt.OnKeyPress(ch);
		} while(ch!='.');

		Console.WriteLine("���� ������ " + ck.count +  "  ������");
        Console.ReadKey();
    }
}






