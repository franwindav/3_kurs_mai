
func = @(x)(sin(x)).^3-(cos(x/2)).^2+2;
%func = @(x)-x.^4+3*x.^3+4*x-5;
%func = @(x)sin(x).^3-3*sin(x.^2)+4*sin(x)+4*x;
%func = @(x)log(10*sin((3*x./5).^2)+1);


string = input('¬ведите нижнюю границу, верхнюю границу, шаг: ','s');
parametr = str2num(string);
x = parametr(1):parametr(3):parametr(2);
h = parametr(3);

y2n = [];

%y0,y2...... дл€ четных x
j = 1;
for i=1:size(x, 2)
    if mod(i,2) == 1
        y2n(j)=func(x(i));
        j = j + 1;
    end
end

y2n1 = [];
%y1,y3....... дл€ нечетных x
j = 1;
for i=1:size(x, 2)
    if mod(i,2) == 0
        y2n1(j)=func(x(i));
        j = j + 1;
    end
end

y0 = y2n(1);
yn = y2n(end);

%сигмы
sig1 = 0;
for i=1:size(y2n1, 2)
    sig1 = sig1 + y2n1(i);
end
sig2 = 0;
for i=2:size(y2n, 2)-1
    sig2 = sig2 + y2n(i);
end

Integral = (h/3)*(y0+yn+4*sig1+2*sig2);

hold on;
fplot(func, [parametr(1), parametr(2)]);
x(end) = [];
legend('f(x)');
xlabel('x');
ylabel('y');


Integral

