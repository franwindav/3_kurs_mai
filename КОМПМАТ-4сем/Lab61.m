%-0.008,-0.066,-0.209,-0.439,-0.734,-1.044,-1.31,-1.484,-1.542,-1.491,-1.366,-1.218,-1.093,-1.02,-0.998,-1,-0.982,-0.901,-0.733,-0.479,-0.174,0.128,0.372,0.513,0.537,0.46,0.323,0.177,0.065,0.009,-0.002

string1 = input('¬ведите значени€ функции: ','s');
func = str2num(string1);
string2 = input('¬ведите нижнюю границу, верхнюю границу, шаг: ','s');
parametr = str2num(string2);
x = parametr(1):parametr(3):parametr(2);
h = parametr(3);

dy1 = zeros(size(func)-1);
%конечна€ разность dy1
for i=1:size(func, 2)-1
   dy1(i) = func(i+1)-func(i); 
end

dy2 = zeros(size(dy1)-1);
%dy2'P
for i=1:size(dy1, 2)-1
   dy2(i) = dy1(i+1)-dy1(i); 
end

dy3 = zeros(size(dy2)-1);
%dy3
for i=1:size(dy2, 2)-1
   dy3(i) = dy2(i+1)-dy2(i); 
end

dy4 = zeros(size(dy3)-1);
%4
for i=1:size(dy3, 2)-1
   dy4(i) = dy3(i+1)-dy3(i); 
end

dy5 = zeros(size(dy4)-1);
%dy5
for i=1:size(dy4, 2)-1
   dy5(i) = dy4(i+1)-dy4(i); 
end

df = zeros(size(func)-1);
%df
for i=1:size(func, 2)-1
    df(i) = 0;
    %прибавить dyi, если есть
    if i<=size(dy1, 2)
        df(i) = df(i) + dy1(i);
    end
    if i<=size(dy2, 2)
        df(i) = df(i) - dy2(i)/2;
    end
    if i<=size(dy3, 2)
        df(i) = df(i) + dy3(i)/3;
    end
    if i<=size(dy4, 2)
        df(i) = df(i) - dy4(i)/4;
    end
    if i<=size(dy5, 2)
        df(i) = df(i) + dy5(i)/5;
    end
    
    df(i) = df(i)/h;
end
%отрисовка
hold on;
plot(x, func);
x(end) = [];
plot(x, df);
legend('f(x)', 'f `(x)');
xlabel('x');
ylabel('y');