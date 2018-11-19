namespace DAL.Entity
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.ComponentModel;

    using Interfaces;
    using Attributes;

    public sealed class PriceList : IDbEntity
    {
        /// <summary>
        /// Id
        /// </summary>
        [Browsable(false)]
        [SaveFieldToDB(Enable = true)]
        public int Id { get; set; }

        /// <summary>
        /// Порядковый номер
        /// </summary>
        [Browsable(false)]
        [SaveFieldToDB(Enable = true)]
        public int Number { get; set; }

        /// <summary>
        /// Уникальный номер
        /// </summary>
        [DisplayName("№")]
        [SaveFieldToDB(Enable = true)]
        public string UID { get; set; }

        /// <summary>
        /// Дата создания
        /// </summary>
        [Browsable(false)]
        [SaveFieldToDB(Enable = true)]
        public DateTime DateCreate { get; set; }

        /// <summary>
        /// Дата создания
        /// </summary>
        [DisplayName("Дата создания")]
        [SaveFieldToDB(Enable = false)]
        public string DateCreateString
        {
            get
            {
                return DateCreate.ToShortDateString();
            }
        }

        /// <summary>
        /// Дата создания
        /// </summary>
        [DisplayName("Дата формирования КП")]
        [SaveFieldToDB(Enable = true)]
        public DateTime DateGeneration { get; set; }



        /// <summary>
        /// Id поставщика
        /// </summary>
        [Browsable(false)]
        [SaveFieldToDB(Enable = true)]
        public int CustomerId { get; set; }

        /// <summary>
        /// Поставщик
        /// </summary>
        [DisplayName("Заказчик")]
        [SaveFieldToDB(Enable = false)]
        public Customer CustomerObject
        {
            get
            {
                return DataManager.Instanse.Customers.GetItemFromID(CustomerId);
            }
        }

        /// <summary>
        /// Id отвественного сотрудника
        /// </summary>
        [Browsable(false)]
        [SaveFieldToDB(Enable = true)]
        public int ResponsibleEmployeeId { get; set; }

        /// <summary>
        /// Отвественный сотрудник
        /// </summary>
        [DisplayName("Отвественный сотрудник")]
        [SaveFieldToDB(Enable = false)]
        public Employee ResponsibleEmployee
        {
            get
            {
                return DataManager.Instanse.Employees.GetItemFromID(ResponsibleEmployeeId);
            }
        }

        /// <summary>
        /// Id состояния КП
        /// </summary>
        [Browsable(false)]
        [SaveFieldToDB(Enable = true)]
        public int PriceListStateId { get; set; }

        /// <summary>
        /// Состояние КП
        /// </summary>
        [DisplayName("Состояние")]
        [SaveFieldToDB(Enable = false)]
        public PriceListState PriceListStateObject
        {
            get
            {
                return DataManager.Instanse.PriceListStates.GetItemFromID(PriceListStateId);
            }
        }

        /// <summary>
        /// Общая сумма (склад)
        /// </summary>
        [DisplayName("Общая сумма (склад)")]
        [SaveFieldToDB(Enable = true)]
        public double TotalSummStory { get; set; }

        /// <summary>
        /// Расходы
        /// </summary>
        [DisplayName("Расходы")]
        [SaveFieldToDB(Enable = true)]
        public double Expenses { get; set; }

        /// <summary>
        /// Общая сумма
        /// </summary>
        [DisplayName("Общая сумма")]
        [SaveFieldToDB(Enable = true)]
        public double TotalSumm { get; set; }

        /// <summary>
        /// Прибыль
        /// </summary>
        [DisplayName("Прибыль")]
        [SaveFieldToDB(Enable = true)]
        public double Profit { get; set; }

        /// <summary>
        /// Затраты на сертификацию
        /// </summary>
        [DisplayName("Затраты на сертификацию")]
        [SaveFieldToDB(Enable = true)]
        public double CertificationCosts { get; set; }

        /// <summary>
        /// Резрешено изменение пользователем
        /// </summary>
        [Browsable(false)]
        [SaveFieldToDB(Enable = true)]
        public bool IsLock { get; set; }

        /// <summary>
        /// Примечание
        /// </summary>
        [Browsable(false)]
        [SaveFieldToDB(Enable = true)]
        public string Note { get; set; }

        /// <summary>
        /// Признак активности срока действия коммерческого предложения
        /// </summary>
        [Browsable(false)]
        [SaveFieldToDB(Enable = true)]
        public bool IsEnabledPeriod { get; set; }

        /// <summary>
        /// Признак активности срока действия коммерческого предложения
        /// </summary>
        [Browsable(false)]
        [SaveFieldToDB(Enable = true)]
        public int TypePeriod { get; set; }

        /// <summary>
        /// Признак активности срока действия коммерческого предложения
        /// </summary>
        [Browsable(false)]
        [SaveFieldToDB(Enable = true)]
        public int Period { get; set; }

        /// <summary>
        /// Список товарных позиций
        /// </summary>
        [Browsable(false)]
        [SaveFieldToDB(Enable = false)]
        public List<ProductPosition> ProductPositions
        {
            get
            {
                return DataManager.Instanse.ProductPositions.GetAllItems().Where(pp => pp.PriceListId == Id).ToList();
            }
        }

    }
}
