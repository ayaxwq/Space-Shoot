using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Weapon : MonoBehaviour
{
    //Объект Particle System, который будет оставлять след от пуль
    [SerializeField] protected GameObject particle;
    //Камера(понадобится для определения центра экрана)
    [SerializeField] protected GameObject cam;
    //Тип стрельбы
    protected bool auto = false;
    //Время задержки между выстрелами и таймер, который считает время
    protected float cooldown = 0;
    protected float timer = 0;

    //При старте приравниваем таймер к задержке между выстрелами
    //Так не будет задержки перед выстрелом
    private void Start()
    {
        timer = cooldown;
    }
    private void Update()
    {
        //Запускаем таймер 
        timer += Time.deltaTime;
        //Если удерживаем клавишу мыши, то вызываем метод Shoot
        if (Input.GetMouseButton(0))
        {
            Shoot();
        }
    }

    //Способность оружия стрелять
    public void Shoot()
    {
        if(Input.GetMouseButtonDown(0) || auto)
        {
            if (timer > cooldown)
            {
                OnShoot();
                timer = 0; 
            }
        }
    }
    //Что происходит при выстреле, эту функцию может менять дочерний класстак она определена модификатором protected virtual
    protected virtual void OnShoot()
    {
        
    }
}
