﻿using System;
using System.Collections.Generic;
using System.Text;

namespace Work8_LINQ
{
    public class DataBase
    {
        List<Group> groups = new List<Group>();
        List<Teacher> teachers = new List<Teacher>();

        public List<Group> Groups { get => groups; set => groups = value; }
        public List<Teacher> Teachers { get => teachers; set => teachers = value; }

        public DataBase()
        {
            #region people
            List<Person> people = new List<Person>();
            people.Add(new Person { Surname = "Ишунина", Name = "Александра", YearOfBirth = 2001 });
            people.Add(new Person { Surname = "Кутузова", Name = "Виталина", YearOfBirth = 2001 });
            people.Add(new Person { Surname = "Коротенко", Name = "Анастасия", YearOfBirth = 2001 });
            people.Add(new Person { Surname = "Андреева", Name = "Виолетта", YearOfBirth = 2001 });
            people.Add(new Person { Surname = "Михаилова", Name = "Елизавета", YearOfBirth = 2001 });
            people.Add(new Person { Surname = "Рользинг", Name = "Полина", YearOfBirth = 2001 });
            people.Add(new Person { Surname = "Берченко", Name = "Андрей", YearOfBirth = 2001 });
            people.Add(new Person { Surname = "Дорофеев", Name = "Александр", YearOfBirth = 2001 });
            people.Add(new Person { Surname = "Баспаков", Name = "Алмат", YearOfBirth = 2001 });
            people.Add(new Person { Surname = "Гаффатуллин", Name = "Денис", YearOfBirth = 2001 });
            people.Add(new Person { Surname = "Шумков ", Name = "Александр", YearOfBirth = 2000 });
            people.Add(new Person { Surname = "Демке  ", Name = "Сергей", YearOfBirth = 2000 });
            people.Add(new Person { Surname = "Желонкин", Name = "Максим", YearOfBirth = 2000 });
            people.Add(new Person { Surname = "Черепанов", Name = "Антон", YearOfBirth = 2000 });
            people.Add(new Person { Surname = "Сиротинин", Name = "Андрей", YearOfBirth = 2000 });
            people.Add(new Person { Surname = "Никулин", Name = "Илья", YearOfBirth = 2000 });
            people.Add(new Person { Surname = "Лавшербанов", Name = "Радион", YearOfBirth = 2000 });
            people.Add(new Person { Surname = "Занковец", Name = "Владислав", YearOfBirth = 2000 });
            people.Add(new Person { Surname = "Дробышев", Name = "Андрей", YearOfBirth = 2000 });
            people.Add(new Person { Surname = "Идиаттулин", Name = "Максим", YearOfBirth = 2000 });
            people.Add(new Person { Surname = "Абрамян", Name = "Павлик", YearOfBirth = 1999 });
            people.Add(new Person { Surname = "Свободский", Name = "Максим", YearOfBirth = 1999 });
            people.Add(new Person { Surname = "Корнилов", Name = "Роман", YearOfBirth = 1999 });
            people.Add(new Person { Surname = "Волков ", Name = "Никита", YearOfBirth = 1999 });
            people.Add(new Person { Surname = "Якумбаев", Name = "Айдар", YearOfBirth = 1999 });
            people.Add(new Person { Surname = "Плотников", Name = "Богдан", YearOfBirth = 1999 });
            people.Add(new Person { Surname = "Асаналиев", Name = "Арслан", YearOfBirth = 1999 });
            people.Add(new Person { Surname = "Бейшенбеков", Name = "Данияр", YearOfBirth = 1999 });
            people.Add(new Person { Surname = "Дергунов", Name = "Дмитрий", YearOfBirth = 1999 });
            people.Add(new Person { Surname = "Шпаков ", Name = "Валентин", YearOfBirth = 1999 });
            people.Add(new Person { Surname = "Горчаков", Name = "Константин", YearOfBirth = 1998 });
            people.Add(new Person { Surname = "Сусанин", Name = "Сергей", YearOfBirth = 1998 });
            people.Add(new Person { Surname = "Юренев ", Name = "Кирил", YearOfBirth = 1998 });
            people.Add(new Person { Surname = "Хромов ", Name = "Кирилл", YearOfBirth = 1998 });
            people.Add(new Person { Surname = "Мокрушников", Name = "Роман", YearOfBirth = 1998 });
            people.Add(new Person { Surname = "Антипин", Name = "Иван", YearOfBirth = 1998 });
            people.Add(new Person { Surname = "Бобылев", Name = "Сергей", YearOfBirth = 1998 });
            people.Add(new Person { Surname = "Туктамышев", Name = "Тимур", YearOfBirth = 1998 });
            people.Add(new Person { Surname = "Мубинов", Name = "Булат", YearOfBirth = 1998 });
            people.Add(new Person { Surname = "Аюпов  ", Name = "Ильшат", YearOfBirth = 1998 });
            people.Add(new Person { Surname = "Агеев  ", Name = "Виктор", YearOfBirth = 2001 });
            people.Add(new Person { Surname = "Баранов", Name = "Александр", YearOfBirth = 2001 });
            people.Add(new Person { Surname = "Басхванов", Name = "Аслан", YearOfBirth = 2001 });
            people.Add(new Person { Surname = "Бобова ", Name = "Елена", YearOfBirth = 2001 });
            people.Add(new Person { Surname = "Валехидис", Name = "Александр", YearOfBirth = 2001 });
            people.Add(new Person { Surname = "Васьковский", Name = "Андрей", YearOfBirth = 2001 });
            people.Add(new Person { Surname = "Вышинский", Name = "Кирилл", YearOfBirth = 2001 });
            people.Add(new Person { Surname = "Галичий", Name = "Владимир", YearOfBirth = 2001 });
            people.Add(new Person { Surname = "Гнатьев", Name = "Сергей", YearOfBirth = 2001 });
            people.Add(new Person { Surname = "Егоров ", Name = "Сергей", YearOfBirth = 2001 });
            people.Add(new Person { Surname = "Ежов   ", Name = "Станислав", YearOfBirth = 2001 });
            people.Add(new Person { Surname = "Еремин ", Name = "Николай", YearOfBirth = 2001 });
            people.Add(new Person { Surname = "Жидких ", Name = "Аркадий", YearOfBirth = 2001 });
            people.Add(new Person { Surname = "Кимаковский", Name = "Игорь", YearOfBirth = 2001 });
            people.Add(new Person { Surname = "Ковалис", Name = "Ольга", YearOfBirth = 2001 });
            people.Add(new Person { Surname = "Кореновский", Name = "Дмитрий", YearOfBirth = 2002 });
            people.Add(new Person { Surname = "Костенко", Name = "Андрей", YearOfBirth = 2002 });
            people.Add(new Person { Surname = "Лазарев", Name = "Сергей", YearOfBirth = 2002 });
            people.Add(new Person { Surname = "Ломако ", Name = "Юрий", YearOfBirth = 2002 });
            people.Add(new Person { Surname = "Мельничук", Name = "Петр", YearOfBirth = 2002 });
            people.Add(new Person { Surname = "Мефедов", Name = "Евгений", YearOfBirth = 2002 });
            people.Add(new Person { Surname = "Одинцов", Name = "Максим", YearOfBirth = 2002 });
            people.Add(new Person { Surname = "Пикалов", Name = "Валерий", YearOfBirth = 2002 });
            people.Add(new Person { Surname = "Просолова", Name = "Юлия", YearOfBirth = 2002 });
            people.Add(new Person { Surname = "Ракушин", Name = "Александр", YearOfBirth = 2002 });
            people.Add(new Person { Surname = "Родионова", Name = "Антонина", YearOfBirth = 2002 });
            people.Add(new Person { Surname = "Саттаров", Name = "Александр", YearOfBirth = 2002 });
            people.Add(new Person { Surname = "Седиков", Name = "Алексей", YearOfBirth = 2002 });
            people.Add(new Person { Surname = "Сидоров", Name = "Денис", YearOfBirth = 2002 });
            people.Add(new Person { Surname = "Тарасенко", Name = "Александр", YearOfBirth = 2002 });
            people.Add(new Person { Surname = "Фёдоров", Name = "Виктор", YearOfBirth = 2002 });
            people.Add(new Person { Surname = "Хитров ", Name = "Денис", YearOfBirth = 2002 });
            people.Add(new Person { Surname = "Хоменко", Name = "Олег", YearOfBirth = 2002 });
            people.Add(new Person { Surname = "Цемах  ", Name = "Владимир", YearOfBirth = 2002 });
            people.Add(new Person { Surname = "Черных ", Name = "Павел", YearOfBirth = 2002 });
            people.Add(new Person { Surname = "Потатин", Name = "Владимир", YearOfBirth = 2000 });
            people.Add(new Person { Surname = "Фридман", Name = "Михаил", YearOfBirth = 2000 });
            people.Add(new Person { Surname = "Усманов", Name = "Алишер", YearOfBirth = 2000 });
            people.Add(new Person { Surname = "Вексельберг", Name = "Виктор", YearOfBirth = 2000 });
            people.Add(new Person { Surname = "Мордашов", Name = "Александр", YearOfBirth = 2000 });
            people.Add(new Person { Surname = "Алекперов", Name = "Вагит", YearOfBirth = 2000 });
            people.Add(new Person { Surname = "Михельсон", Name = "Леонид", YearOfBirth = 2000 });
            people.Add(new Person { Surname = "Лисин  ", Name = "Владимир", YearOfBirth = 2000 });
            people.Add(new Person { Surname = "Тимченко", Name = "Геннадий", YearOfBirth = 2000 });
            people.Add(new Person { Surname = "Прохоров", Name = "Михаил", YearOfBirth = 1999 });
            people.Add(new Person { Surname = "Курскиева", Name = "Аза", YearOfBirth = 1999 });
            people.Add(new Person { Surname = "Магомедов", Name = "Саид", YearOfBirth = 1999 });
            people.Add(new Person { Surname = "Бекбенбетова", Name = "Малика", YearOfBirth = 1999 });
            people.Add(new Person { Surname = "Семёнова", Name = "Виктория", YearOfBirth = 1999 });
            people.Add(new Person { Surname = "Герасимчук", Name = "Евгений", YearOfBirth = 1999 });
            people.Add(new Person { Surname = "Омаркадиев", Name = "Ильяс", YearOfBirth = 1999 });
            people.Add(new Person { Surname = "Медова ", Name = "Жаннатин", YearOfBirth = 1999 });
            people.Add(new Person { Surname = "Лим    ", Name = "Маргарита", YearOfBirth = 1999 });
            people.Add(new Person { Surname = "Молчан ", Name = "Полина", YearOfBirth = 1999 });
            people.Add(new Person { Surname = "Бембеева", Name = "Анастасия", YearOfBirth = 2001 });
            people.Add(new Person { Surname = "Квон   ", Name = "Елена", YearOfBirth = 2001 });
            people.Add(new Person { Surname = "Лобкова", Name = "Вероника", YearOfBirth = 2001 });
            people.Add(new Person { Surname = "Полосина", Name = "Анастасия", YearOfBirth = 2001 });
            people.Add(new Person { Surname = "Спарбер", Name = "Мария", YearOfBirth = 2001 });
            people.Add(new Person { Surname = "Аверьянов", Name = "Семен", YearOfBirth = 2001 });
            people.Add(new Person { Surname = "Алышева", Name = "Ольга", YearOfBirth = 2001 });
            people.Add(new Person { Surname = "Гальперин", Name = "Михаил", YearOfBirth = 2001 });
            people.Add(new Person { Surname = "Емельяненко", Name = "Екатерина", YearOfBirth = 2001 });
            people.Add(new Person { Surname = "Зенькович", Name = "Екатерина", YearOfBirth = 2001 });
            people.Add(new Person { Surname = "Зубарев", Name = "Александр", YearOfBirth = 2000 });
            people.Add(new Person { Surname = "Кощеев  ", Name = "Ниджат", YearOfBirth = 2000 });
            people.Add(new Person { Surname = "Нагорный", Name = "Антон", YearOfBirth = 2000 });
            people.Add(new Person { Surname = "Ульбашев", Name = "Мурат", YearOfBirth = 2000 });
            people.Add(new Person { Surname = "Фанкин ", Name = "Николай", YearOfBirth = 2000 });
            people.Add(new Person { Surname = "Алексеева", Name = "Ксения", YearOfBirth = 2000 });
            people.Add(new Person { Surname = "Анатов ", Name = "Глеб", YearOfBirth = 1999 });
            people.Add(new Person { Surname = "Благов ", Name = "Максим", YearOfBirth = 1999 });
            people.Add(new Person { Surname = "Болодурина", Name = "Анна", YearOfBirth = 1999 });
            people.Add(new Person { Surname = "Булыгина", Name = "Анна", YearOfBirth = 1999 });
            people.Add(new Person { Surname = "Гордиенко", Name = "Артур", YearOfBirth = 1999 });
            people.Add(new Person { Surname = "Занина ", Name = "Анна", YearOfBirth = 1999 });
            people.Add(new Person { Surname = "Зимин  ", Name = "Ярослав", YearOfBirth = 1999 });
            people.Add(new Person { Surname = "Карташова", Name = "Наталья", YearOfBirth = 1999 });
            people.Add(new Person { Surname = "Медведева", Name = "Татьяна", YearOfBirth = 1999 });
            people.Add(new Person { Surname = "Муравьева", Name = "Валерия", YearOfBirth = 1999 });


            int countPeople = 0;
            int count = 0;
            for (int i = 0; i < 4; i++) // курсы
            {
                for (int o = 0; o < 3; o++) // группы
                {
                    Group group = new Group { };
                    switch (i) // по курсам
                    {
                        case 0: group.NameGroup = "П-1"; group.Course = 1; break;
                        case 1: group.NameGroup = "П-2"; group.Course = 2; break;
                        case 2: group.NameGroup = "П-3"; group.Course = 3; break;
                        case 3: group.NameGroup = "П-4"; group.Course = 4; break;
                    }
                    switch (o) // по группам
                    {
                        case 0: group.NameGroup += "04"; break;
                        case 1: group.NameGroup += "27"; break;
                        case 2: group.NameGroup += "20"; break;
                    }

                    for (int p = 0; p < 10; p++) // каждой группе по 10 человек
                    {
                        if (countPeople % 5 == 0)
                        {
                            people[countPeople].Dictionary.Add("Математика", 5);
                            people[countPeople].Dictionary.Add("Русский", 5);
                            people[countPeople].Dictionary.Add("Английский", 5);
                            people[countPeople].Dictionary.Add("География", 5);
                            people[countPeople].Dictionary.Add("Физкультура", 5);
                            people[countPeople].Dictionary.Add("Сверхразум", 5);
                            count++;
                        }
                        else
                        {
                            people[countPeople].Dictionary.Add("Математика", 1 + count % 4);
                            count++;
                            people[countPeople].Dictionary.Add("Русский", 2 + count % 4);
                            count++;
                            people[countPeople].Dictionary.Add("Английский", 2 + count % 4);
                            count++;
                            people[countPeople].Dictionary.Add("География", 1 + count % 4);
                            count++;
                            people[countPeople].Dictionary.Add("Физкультура", 2 + count % 4);
                            count++;
                        }
                        group.People.Add(people[countPeople]);
                        countPeople++;
                    }
                    groups.Add(group);
                }
            }
            #endregion

            #region teachers
            teachers.Add(new Teacher { Surname = "Алимов ", Name = "Дмитрий", CourseWork = 1 });
            teachers.Add(new Teacher { Surname = "Ангриков", Name = "Сергей", CourseWork = 1 });
            teachers.Add(new Teacher { Surname = "Грибанов", Name = "Виталий", CourseWork = 1 });
            teachers.Add(new Teacher { Surname = "Желшев ", Name = "Руслан", CourseWork = 2 });
            teachers.Add(new Teacher { Surname = "Крылов ", Name = "Павел", CourseWork = 2 });
            teachers.Add(new Teacher { Surname = "Ложкин ", Name = "Евгений", CourseWork = 2 });
            teachers.Add(new Teacher { Surname = "Марченко", Name = "Влад", CourseWork = 3 });
            teachers.Add(new Teacher { Surname = "Насонова", Name = "Екатерина", CourseWork = 3 });
            teachers.Add(new Teacher { Surname = "Резаев ", Name = "Сахават", CourseWork = 3 });
            teachers.Add(new Teacher { Surname = "Старухина", Name = "Елена", CourseWork = 4 });
            teachers.Add(new Teacher { Surname = "Халявина", Name = "Светлана", CourseWork = 4 });
            teachers.Add(new Teacher { Surname = "Федоров", Name = "Артем", CourseWork = 4 });
            #endregion
        }
    }
}
