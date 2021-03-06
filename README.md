# **Primal Bomberman**
## **Información General**
<br>

Este proyecto tiene como finalidad poner en practica los conocimientos y herramientas aportados por el paradigma de programación orientada a objetos (POO) a traves de la programación de una versión modificada e inspirada en el juego [Bomberman](https://es.wikipedia.org/wiki/Bomberman), más que todo en el [Super Bomberman 4](https://es.wikipedia.org/wiki/Super_Bomberman_4).

<br>

El motivo del "Primal" antes del Bomberman, se atribuye a dos hechos:

1. Es el primer proyecto realizado en el motor de videojuegos [Unity](https://unity.com/es), el cual fue trabajado en [C#](https://es.wikipedia.org/wiki/C_Sharp), todas la herramientas de Unity permitieron una fácil comprensión de cómo funciona, además de la innvaluable cantidad de información que se encuentra en la web, bien sea en videos, documentos oficiales  y blogs, los cuales ayudaron de forma inmensa a comprender cómo programar en C# y cómo funciona Unity.
2. El juego se desarrolla en el ambiente "Primal Era" del juego Super Bomberman 4, así que de esta forma, se le está rindiendo tributo al juego que inspiró este proyecto.

<br>

## **Disclaimer**
Todos los materiales visuales relacionados con la franquicia Bomberman y el juego Super Bomberman 4 pertenecen a la compañía [Hudson Soft](https://es.wikipedia.org/wiki/Hudson_Soft), (creadora de videojuegos Japonesa), no se está intentando por ningun medio declarar que se poseen los derechos de las franquicios antes mencionadas, el uso de estos elementos es por estética y tributo al juego Super Bomberman 4.

<br>

____

## **Descripción del Juego e Instrucciones**

<br>
Para jugar a ``Primal Bomberman`` se necesita de un teclado, (preferiblemente que no sea de teclado) para tener una mejor experiencia en el juego, este es un multijugador local en el cual dos jugadores se enfrentan entre sí, aquel que logre eliminar al otro es ganador de la partida, durante la cual, los jugadores podrán recoger ``PowerUps`` que potenciarán sus habilidades y darles una pequeña ventaja durante el combate.

<br>

El primer jugador, utilizará las teclas de dirección (Arriba,Abajo,Derecha e Izquierda) para poder moverse y colocará bombas con la tecla de punto ("."). 
El segundo jugador (Ninja Verde) utilizará las teclas W,A,S y D (W = Arriba, S =Abajo, D =Derecha y A = Izquierda) para poder moverse y colocará bombas con la tecla v ("v").

<br>

____

## **Clases Principales**
A pesar de que se usaron varias clases durante el desarrollo de este proyecto, se incluirán aquellas que fueron especialemtne útiles para este programa y sería útiles para aquellos similares a este, aunque antes de describirlas, se hablará del concepto de [Tilemaps](https://docs.unity3d.com/2019.3/Documentation/Manual/class-Tilemap.html).

<br>

## **Tilemaps**
Una manera sencilla de resumir esta herramienta es la siguiente: Consta de una matriz en dos dimensiones, la cual puede registrar distintos ``Tiles`` o cuadros dentro de cada celda que posee, por medio del ``Tilemap Renderer`` se le pueden dar imágenes a estsas celdas, además de interacción física con otros objetos, ya que esta herramienta permite darle una ``Hitbox`` o área de contacto a cualquier pieza que se coloque dentro de esta, el uso de Tilemaps en este proyecto fue esencial ya que facilitó la interacción de los objetovs movibles con el escenario, además de permitir darle un toque organizado y esquematizado al proyecto.
____
## **TileDestroyer**
Esta clase se encarga de destruir cierto tipo de ``Tiles`` dentro del Tilemap seleccionado, sus métodos le permiten conocer que tipo de celda no debe eliminar y cual si en caso de que una bomba explote cerca.

<br>

### ``RemoveCell()``

<br>

````C#
 bool RemoveCell(Vector3Int cell)
    {
        Tile TileKind = Grid.GetTile<Tile>(cell);

        if(TileKind == Wall)
        {
            return false;
        }
        if(TileKind == Border)
        {
            return false;
        }

        if(TileKind == Breakable)
        {
            Grid.SetTile(cell, null);
            Vector3 PowerPos = Grid.GetCellCenterWorld(cell);
            random = UnityEngine.Random.Range(0,8);
            switch (random)
            {
                case 0:
                    Instantiate(FirePowerUp, PowerPos, Quaternion.identity);
                    break;
                case 1:
                    Instantiate(SkatePowerUp, PowerPos, Quaternion.identity);
                    break;
            }
        }

        Vector3 Pos = Grid.GetCellCenterWorld(cell);
        Instantiate(BoomAnimation, Pos, Quaternion.identity);

        return true;
    }


}

````
Este método se encarga de diferenciar que ``Tiles`` debe de eliminar y en cuales debe de causar una explosión, además, si la celda eliminada era una "Rompible" existe una probabilidad de que aparezca un ``PowerUp`` que ayude al jugador.

<br>

### ``Explode()``

<br>

````C#
public void Explode(Vector2 PosInWorld)
    {
        Vector3Int ExplosionCenter = Grid.WorldToCell(PosInWorld);
        Player1 BombPower = Player1.GetComponent<Player1>();
        n = BombPower.BombPower;
        if (RemoveCell(ExplosionCenter))
        {
            for (int i = 1; i < n; i++)
            {
                if (RemoveCell(ExplosionCenter + new Vector3Int(i, 0, 0)))
                {
                    RemoveCell(ExplosionCenter + new Vector3Int(i + 1, 0, 0));
                    continue;
                }
                break;
            }
            for (int i = 1; i < n; i++)
            {
                if (RemoveCell(ExplosionCenter + new Vector3Int(0, i, 0)))
                {
                    RemoveCell(ExplosionCenter + new Vector3Int(0, i + 1, 0));
                    continue;
                }
                break;
            }
            for (int i = 1; i < n; i++)
            {
                if (RemoveCell(ExplosionCenter + new Vector3Int(-i, 0, 0)))
                {
                    RemoveCell(ExplosionCenter + new Vector3Int(-(i + 1), 0, 0));
                    continue;
                }
                break;
            }
            for (int i = 1; i < n; i++)
            {
                if (RemoveCell(ExplosionCenter + new Vector3Int(0, -i, 0)))
                {
                    RemoveCell(ExplosionCenter + new Vector3Int(0, -(i + 1), 0));
                    continue;
                }
                break;
            }
        }
    }

}
````
La siguiente función recibe el ``BombPower`` o fuerza de la bomba de un jugador y se ejecuta en el centro de la explosión, alargándose n cuadros hacia todas las direcciones, como lo evidencia el código.

<br>

____

## **Player**
Esta clase permite el movimiento del jugador y su interacción con el ambiente, no es sorprendente observar este tipo de clases en un juego como Bomberman.

<br>

### ``Update()``

<br>

````C#
// Update is called once per frame
    void Update()
    {
        // Reads Horizontal axis 
        if(Input.GetKey("right"))
        {
            movement.x = 1;
        }
        else if(Input.GetKey("left"))
        {
            movement.x = -1;
        }
        else
        {
            movement.x = 0;
        }

        // Reads Vertical axis
        if(Input.GetKey("up"))
        {
            movement.y = 1;
        }
        else if(Input.GetKey("down"))
        {
            movement.y = -1;
        }
        else
        {
            movement.y = 0;
        }

        animator.SetFloat("Horizontal", movement.x);
        animator.SetFloat("Vertical", movement.y);
        animator.SetFloat("Speed", movement.sqrMagnitude);

    }
}

````
El método update permite que el código que se escriba dentro de él, se llame a cada cuadro o ``frame`` mientras el objeto exista o esté en escena, se puede evidenciar que se colocaron los detectores de movimiento dentro de este para poder mover al objeto ``Player``.

<br>

### ``Dies()``

<br>

````C#
public void Dies()
    {
        Renderer rend = PlayerCharacter.GetComponent<Renderer>();
        Instantiate(DieAnimation, PlayerCharacter.transform.position, Quaternion.identity);
        rend.enabled = false;
        Player1 function = PlayerCharacter.GetComponent<Player1>();
        function.enabled = false;
        transform.position = new Vector3Int(20, 20, 20);
        Alive = 0;
    }
    
    
}
````
Este método se activa cuando el jugador colisiona con una explosión, causando que se llame a la animación de muerte, se deje de mostrar a su ``Sprite``, además de impedirle colocar más bombas y realizar cualquier movimiento.

<br>

____

## **BombSpawner**

Esta clase se encarga de colocar la bombas en el tablero, lo primero que hace es recibir un input específico, seguido de unas coordenadas a las cuales convierte en coordenadas del Tilemap, permitiendo siempre colocar las bombas en el centro de la celda más cercana al jugador que oprimio su tecla para colocar una bomba.

<br>

### ``Update()``

<br>

````C#
void Update()
    {
        Player1 AliveVerifier_1 = Player1.GetComponent<Player1>();
        Player2 AliveVerifier_2 = Player2.GetComponent<Player2>();
        
        IsAlive_1 = AliveVerifier_1.Alive;
        IsAlive_2 = AliveVerifier_2.Alive;

        if (Input.GetKeyDown("."))
        {
            if (IsAlive_1 == 1)
            {
                PosX = (int)(Mathf.Floor(Player1.transform.position.x));
                PosY = (int)(Mathf.Floor(Player1.transform.position.y));
                Vector3Int CellPos = new Vector3Int(PosX, PosY, 0);
                Vector3 CenterPos = tilemap.GetCellCenterWorld(CellPos);
                Instantiate(bombP, CenterPos, Quaternion.identity);
            }
        }

        if (Input.GetKeyDown("v"))
        {
           if (IsAlive_2 == 1)
            {
                PosX = (int)(Mathf.Floor(Player2.transform.position.x));
                PosY = (int)(Mathf.Floor(Player2.transform.position.y));
                Vector3Int CellPos = new Vector3Int(PosX, PosY, 0);
                Vector3 CenterPos = tilemap.GetCellCenterWorld(CellPos);
                Debug.Log(CellPos);
                Instantiate(bomb_2, CenterPos, Quaternion.identity);
            } 
        }
        
    }
}
````
Debido a que el siguiente método se llama cada frame, el jugador puede presionar en cualquier momento su tecla encargada para colocar su bomba, las funciones son casi las mismas, solo que se refieren a dos objetos diferentes ya que se trata de dos jugadores.

<br>

____

## **Destroy**

Esta clase se encarga de detectar si el jugador choca con una explosión, devolviendo como respuesta el método ``Dies()`` antes mencionado, este controla al objeto ``Explosion``, permitiendo encargarse de los clones de este anterior mencionado una vez su animación ha terminado.

<br>

### ``OnTriggerEnter2D(Collider2D collider)``

````C#
private void OnTriggerEnter2D(Collider2D collider)
    {
        if (collider.CompareTag("Player"))
        {
            Player = GameObject.FindGameObjectWithTag("Player").GetComponent<Player1>();
            Player.Dies();
        }

        else if (collider.CompareTag("Player_2"))
        {
            Player_2 = GameObject.FindGameObjectWithTag("Player_2").GetComponent<Player2>();
            Player_2.Dies();
        }

        else if(collider.CompareTag("PowerUp"))
        {
            Debug.Log("Dead object");
        }
        
    }
}
````
Este método se encarga de detectar la colisión de una explosión con alguno de los dos jugadores para así llamar al método ``Dies()`` del jugador detectado.

<br>

### ``DestroyItself()``
````C#
    private void DestroyItself()
    {
        Destroy(gameObject);
    }
}
````
Este método se encarga de destruir al objeto clon una vez su animación termina, esto ya que tener muchos clones puede causar errores de colisión y llevar a un fin del juego tempranero o un posible error.

<br>

____

## **PowerUpCollision**
La siguiente clase permite al jugador recoger ``PowerUps``, los cuales le darán una pequeña ventaja a la hora de enfentarse a su contraparte.

<br>

### ``OnTriggerEnter2D(Collider2D collider)``
````C#
private void OnTriggerEnter2D(Collider2D collider){
        if (collider.CompareTag("Player"))
        {
            Pickup(collider);
        }
        if (collider.CompareTag("Player_2"))
        {
            Pickup_2(collider);
        }


    }
}
````
Como ya se mencionó antes, este método sirve para detectar colisiones, en este caso el objeto ``PowerUp`` detecta cuando el jugador está cerca y ejecuta otro de sus métodos.

<br>

### ``Pickup()``
````C#
void Pickup(Collider2D player)
    {
        Player1 power = player.GetComponent<Player1>();
        power.BombPower += 1;
        Destroy(gameObject);
    }
}
````
Este método accede a la característica de ``BombPower`` o a la de ``movSpeed`` para aumentar la potencia de sus bombas o su velocidad de movimiento respectivamente, cabe destacar que los jugadores cuentan con sus estadísticas propias.

<br>

## **Referencias**
Las referencias forman una gran parte de este proyecto, pues ambos participantes eramos nuevos a Unity, teniendo muchas opciones por donde empezar pero sin saber cuál era la mejor, dentro de estas opciones que ayudaron bastante a la comprensión de Unity, sus mecánicas y su forma de hacer que los objetos interactúan entre sí, están:

1. [Brackyes](https://www.youtube.com/user/Brackeys), Un grupo de personas que realizaban tutoriales básicos acerca de Unity y sus mecánicas, la forma de explicar de su presentador y lo simple que hace ver las cosas nos permitió entender el lenguaje C#.
2. [CouchFerret makes Games](https://www.youtube.com/channel/UCp5WDvPDLCkSZWp9hP5xIvQ), Un youtuber dedicado a realizar tutoriales de Unity, permitió un mayor entendimiento en su video acerca de [colisiones](https://www.youtube.com/watch?v=Cry7FOHZGN4&ab_channel=CouchFerretmakesGames).
3. [Unity User Manual (2019.4 LTS)](https://docs.unity3d.com/Manual/index.html), La documentación de Unity que permitía saber la esencia de una mecánica para poder terminar de entenderla al lado de la práctica.

Además de contar con referencias que ayudaron a comprender el motor de videojuegos de Unity, aún faltaban los sprites para lograr un efecto visual atractivo, por suerte, la mayoría de estos se encontraban en [spriters-resource](https://www.spriters-resource.com/snes/sbomber4/sheet/59913/), una página dedicada a distribuir sprites.

<br>

## **Conclusiones y proyectos a futuro**
Gracias a las referencias y a la experiencia vivida usando el motor de búsqueda de Unity, se llegó a la conclusón de que es muy valioso aprender a realizar juegos o esquemas relacionados a estos sin utilizar un motor de videojuegos como Unity, ya que de esta forma se construyen fundamentos útiles para posteriormente ser conciente en todo momento de lo que se está haciendo, lo que permite valorar la inmensa gama de herramientas que ofrece un motor de videojuegos.

<br>

El paradigma de la [Programación Orientada a Objetos](https://es.wikipedia.org/wiki/Programaci%C3%B3n_orientada_a_objetos) permite la correcta comunicación e interacción entre los distintos elementos y herramientas de un proyecto como lo es este y muchos más, realizados en motores de videojuegos como lo es Unity o similares.
