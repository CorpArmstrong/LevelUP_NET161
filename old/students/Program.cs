using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using StudentsProgress.Logic;
using StudentsProgress.GUI;
using StudentsProgress.Data;


namespace StudentsProgress
{
    class Program
    {

        static void Main(string[] args)
        {
            bool exit = false;

            Common.Student[] students = new Common.Student[Common.randomValue.Next(29, 40)];
            StudentsHelperMethods.StudentsInit(students);
            ConsoleGraphic.InitConsole(Console.WindowWidth, students.Length + ConsoleGraphic.menuVerticalPadding * 2);

            int selectedStudent = 0; // индекс выбранного студента
            bool menuNotChanged = true; // изменяли ли мы размерность меню, если да - то перерисовка меню полностью, если нет то выводим поверх

            while (!exit) // главный управляющий цикл (отображение группы)
            {
               Common.TaskIndex taskIndex; // код задачи (-1 - выбор не сделан либо нажат enter(просмотр данных), 0 - удаление поля, 1 - добавление, 2 - изменение)

                selectedStudent = ConsoleMenu.NavigateMenu("Список студентов", StudentsHelperMethods.GetStudents(students), out taskIndex, selectedStudent, menuNotChanged); // Прорисовка меню списка студентов и возврат выбранных данных
                menuNotChanged = true; // "обнуляем" маркер изменения всего списка

                if (selectedStudent != -1) // если выбрали студента (-1 - нажат esc)
                {
                    switch (taskIndex) // если студент выбран, то смотрим какую задачу сделать
                    {
                        case Common.TaskIndex.REMOVE: // удаление выбранного студента
                            {
                                StudentsHelperMethods.RemoveArrayElement(ref students, selectedStudent);
                                menuNotChanged = false;
                                if (selectedStudent != 0)
                                {
                                    selectedStudent--;
                                }
                                ConsoleGraphic.InitConsole(Console.WindowWidth, students.Length + ConsoleGraphic.menuVerticalPadding * 2);
                                break;
                            }
                        case Common.TaskIndex.ADD:  // добавление нового студента
                            {
                                Data.Common.Student[] student = new Data.Common.Student[1];
                                StudentsHelperMethods.StudentsInit(student);
                                StudentsHelperMethods.AddArrayElement(ref students, student[0]);
                                menuNotChanged = false;
                                ConsoleGraphic.InitConsole(Console.WindowWidth, students.Length + ConsoleGraphic.menuVerticalPadding * 2);
                                break;
                            }
                        case Common.TaskIndex.NONE: // нажат enter. значит выбран просмотр полей студента
                            {
                                #region StudentFields
                                int selectedStudentField = 0; // индекс выбранного поля студента
                                while (true) // отображение данных студента
                                {
                                    selectedStudentField = ConsoleMenu.NavigateMenu("Данные студента", students[selectedStudent].GetStudentInfo(), out taskIndex, selectedStudentField, true, true); // Прорисовка данных конкретного студента

                                    if (selectedStudentField != -1) // если выбрали поле студента (-1 - нажат esc)
                                    {
                                        switch (taskIndex) // код задачи (-1 - выбор не сделан либо нажат enter(просмотр данных), 0 - удаление поля, 1 - добавление, 2 - изменение)
                                        {
                                            case Common.TaskIndex.REMOVE: // удаление поля, если это оценки (индекс больше 2)
                                                {
                                                    if (selectedStudentField > 2)
                                                    {
                                                        CommonHelperMethods.RemoveIntArrayElement(ref students[selectedStudent]._studentGrades, selectedStudentField);
                                                        if (selectedStudentField > 0)
                                                            selectedStudentField--;
                                                    }
                                                    ConsoleGraphic.OutputTextInFrame("Список студентов", StudentsHelperMethods.GetStudents(students), selectedStudent, true, false); // перерисовка предыдущего меню

                                                    break;
                                                }
                                            case Common.TaskIndex.ADD: // добавление оценок
                                                {
                                                    int inputValue = ConsoleMenu.ReadIntValueFromConsole("Введите оценку");
                                                    CommonHelperMethods.AddIntArrayElement(ref students[selectedStudent]._studentGrades, inputValue);
                                                    if (selectedStudentField < students[selectedStudent]._studentGrades.Length - 1)
                                                        selectedStudentField++;
                                                    ConsoleGraphic.OutputTextInFrame("Список студентов", StudentsHelperMethods.GetStudents(students), selectedStudent, true, false); // перерисовка предыдущего меню

                                                    break;
                                                }
                                            case Common.TaskIndex.EDIT: // изменение любого выбранного поля
                                                {
                                                    if (selectedStudentField == 0) // изменение номера зачетки
                                                    {
                                                        int inputValue = ConsoleMenu.ReadIntValueFromConsole("Введите новое значение");
                                                        students[selectedStudent]._recordBookNumber = inputValue;
                                                    }
                                                    else if (selectedStudentField == 1 || selectedStudentField == 2) // изменение имени или фамилии
                                                    {
                                                        string inputValue = ConsoleMenu.ReadStringValueFromConsole("Введите новое значение");

                                                        if (selectedStudentField == 1)
                                                            students[selectedStudent]._name = inputValue;
                                                        else
                                                            students[selectedStudent]._secondName = inputValue;
                                                    }
                                                    else // изменение оценки
                                                    {
                                                        int inputValue = ConsoleMenu.ReadIntValueFromConsole("Введите новое значение");
                                                        students[selectedStudent]._studentGrades[selectedStudentField - 3] = inputValue;
                                                    }

                                                    ConsoleGraphic.OutputTextInFrame("Список студентов", StudentsHelperMethods.GetStudents(students), selectedStudent, true, false); // перерисовка предыдущего меню

                                                    break;
                                                }
                                            default:
                                                break;
                                        }
                                    }
                                    else
                                    {
                                        menuNotChanged = false;
                                        break;
                                    }
                                }
                                #endregion

                                break;
                            }
                        case Common.TaskIndex.AVERAGE_GRADE:
                            {
                                int av = CommonHelperMethods.GetAverageValue(students[selectedStudent]._studentGrades);
                                ConsoleGraphic.OutputTextInFrame("Средняя оценка студента", new string[] { av.ToString() },-1, true, true);
                                ConsoleGraphic.Wait();
                                break;
                            }
                        case Common.TaskIndex.BEST_STUDENT:
                            {
                                selectedStudent = StudentsHelperMethods.GetBestStudent(students);

                                break;
                            }
                        case Common.TaskIndex.WORST_STUDENT:
                            {
                                selectedStudent = StudentsHelperMethods.GetWorstStudent(students);

                                break;
                            }
                        default:
                            break;
                    }
                }
                else
                {
                    selectedStudent = 0;
                }
            }
        }
    }
}
