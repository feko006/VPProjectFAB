# Squarelactica
![logo](http://i.imgur.com/9HJX4c3.png)

##1. Опис

Squarelactica е игра во која двајца играчи на 2 различни страни од екранот се обидуваат да го уништат квадратот на спротивниот играч односно да го испразнат нивниот енергетски бар.

##2. Структура на имплементација

Со цел да се имплементира оваа идеја, користени се класите Player, Bullet и Game.

###2.1 Player класа

Во оваа класа се чуваат координатите на играчот, димензиите, нивата максимална и тековна енергија, брзината со која играчот се движи низ екранот, како и сет од објекти од класата Bullet.

Методите со кои располага оваа класа се испалување на куршум (fire), движење нагоре или надолу (moveUp, moveDown), активирање на штит (activateShield) и функции за менување на состојба и исцртување (update, draw).

###2.2 Bullet класа

Во оваа класа се чуваат координатите, димензиите и брзината на куршумите кои се испалуваат од играчот при кликнување на соодветно копче.

Методите на оваа класа овозможуваат движење и исцртување (move, draw).

###2.3 Game класа

Целта на оваа класа е заедно со класата од самата форма да го регулираат текот на извршување на играта, кога се наоѓа во состојба на играње.

Во оваа класа се проверуваат колизии помеѓу куршуми и играчи (checkCollisions), се менува состојбата и се исцртуваат играчите заедно со нивните елементи.

##3. Опис на функции
Функциите се документирани.

####Game.update() - функција која се повикува во тајмерот пред да се повика draw() функцијата
```c#
        /// <summary>
        /// Updates the players before drawing them
        /// </summary>
        public void update()
        {
            checkCollisions();
            player1.update();
            player2.update();
        }
```
*Повикува проверка за колизии, и подоцна update() функциите на двата играчи

####Player.update() - функција за обновување на играчот
```c#
        /// <summary>
        /// Update function that moves the bullets
        /// </summary>
        public void update()
        {
            if (specialPowerCounter > 0 && !SpecialPower)
            specialPowerCounter--; // se namaluva brojachot za cooldown na shtitot
            if (specialPowerCounter == 1 || specialPowerCounter == 2) // koga kje stane 0 aka slobodno
                blinkGreen = true; //kje blinkne zeleno
            else
                blinkGreen = false; // inaku se gasi
            
            if (Bullets.Count > 0)
                foreach (Bullet bullet in Bullets)
                {
                    bullet.move();
                }
        }
```
Секој од објектите за играчите преку оваа функција се грижи за движењата на куршумите, и се искористува оваа функција дека се случува еднаш во секој frame за преку неа да работи бројачот за штитот.

####Player.fire() - функција преку која пука играчот
```c#
        /// <summary>
        /// Fires a bullet (creates new one)
        /// </summary>
        public void fire()
        {
            int bulletOffset = Width;
            if (BulletSpeed < 0)
                bulletOffset = -bulletOffset;
            Bullets.Add(new Bullet(X + bulletOffset, Y + 20, 5, 50, BulletSpeed));
        }
```

##4. Скриншот од завршена игра

###4.1 Почетен екран
![startingscreen](http://i.imgur.com/BzO7gZI.png)

###4.2 Во игра
![ingame](http://i.imgur.com/HvpZByf.png)

##5. Инструкции

Целта на двата играчи е да избегнуваат куршуми од спротивниот играч и воедно да се обидуваат да го погодат. Левиот играч се движи со помош на копчињата W и S, пука на F, а штитот кој спречува еден куршум од спротивниот играч го користи со притискање на G. Десниот играч се движи со помош на стрелките нагоре надолу, пука на бројката 0 на numpad-от, а штитот го активира на 1 исто така од numpad-от.

Енергијата на играчите е исцртана со барови соодветно на левата и десната страна за левиот и десниот играч. Кога енергијата станува ниска се менува бојата во црвена. Кога едниот играч ќе остане со празен енергетски бар, тој играч ја губи играта со што другиот играч победува.
