using System.Collections.ObjectModel;
using System.Linq;
using Telerik.Windows.Controls;
using SunSeven.DataSource;
using SunSeven.Models;

namespace SunSeven.ViewModels
{

    public class vmConfiguration : commandCollection
    {

        private ObservableCollection<HSCategory> hsCollection = null;
        private ObservableCollection<HSSellingUnit> hsCollection2 = null;
        private ObservableCollection<HSDepartment> hsCollection3 = null;

        private ObservableCollection<HSClientType> hsClientTypes = null;

        private ObservableCollection<HSRole> hsRoles = null;

        private ObservableCollection<HSVatRate> hsVATRates = null;

        SunSeven.DataSource.JSDataContext lDataContext;

        RadGridView myGrid;
        public vmConfiguration()
        {
            lDataContext = new CommonFunction().JSDataContext();
        }

        public vmConfiguration(object pGrid)
        {
            myGrid = pGrid as RadGridView;
            lDataContext = new CommonFunction().JSDataContext();
        }

        public ObservableCollection<HSCategory> Categories
        {
            get
            {
                if (this.hsCollection == null)
                {
                    try
                    {
                        hsCollection = new ObservableCollection<HSCategory>();

                        foreach (SunSeven.DataSource.Category l in lDataContext.Categories.Where(p => p.ParentId == null))
                        {
                            //ObservableCollection<HSCategory> subCatetory = new ObservableCollection<HSCategory>();

                            //foreach(SunSeven.DataSource.Category ll in lDataContext.Categories.Where(p => p.ParentId == l.Id))
                            //{
                            //    hsCollection.Add(new HSCategory
                            //    {
                            //        Id = ll.Id,
                            //        ParentId = ll.ParentId,
                            //        CategoryName = ll.Name                     

                            //    });
                            //}

                            hsCollection.Add(new HSCategory
                            {
                                Id = l.Id,
                                ParentId = l.ParentId,
                                CategoryName = l.Name,
                                // Subcategory = subCatetory

                            });
                        }
                    }
                    catch
                    {
                        return null;
                    }
                }

                return this.hsCollection;
            }
        }

        public ObservableCollection<HSSellingUnit> SellingUnits
        {
            get
            {
                if (this.hsCollection2 == null)
                {
                    try
                    {
                        hsCollection2 = new ObservableCollection<HSSellingUnit>();

                        foreach (SunSeven.DataSource.SellingUnit l in lDataContext.SellingUnits)
                        {
                            hsCollection2.Add(new HSSellingUnit
                            {
                                Id = l.Id,
                                Unit = l.Unit

                            });
                        }
                    }
                    catch
                    {
                        return null;
                    }
                }

                return this.hsCollection2;
            }
        }

        public ObservableCollection<HSDepartment> Departments
        {
            get
            {
                if (this.hsCollection3 == null)
                {
                    try
                    {
                        hsCollection3 = new ObservableCollection<HSDepartment>();

                        foreach (SunSeven.DataSource.Department l in lDataContext.Departments)
                        {
                            hsCollection3.Add(new HSDepartment
                            {
                                Id = l.Id,
                                Name = l.Name
                            });
                        }
                    }
                    catch
                    {
                        return null;
                    }
                }

                return this.hsCollection3;
            }
        }

        public ObservableCollection<HSClientType> ClientTypes
        {
            get
            {
                if (this.hsClientTypes == null)
                {
                    try
                    {
                        this.hsClientTypes = new ObservableCollection<HSClientType>();

                        foreach (SunSeven.DataSource.ClientType l in lDataContext.ClientTypes)
                        {
                            hsClientTypes.Add(new HSClientType
                            {
                                Id = l.Id,
                                Type = l.Type
                            });
                        }
                    }
                    catch
                    {
                        return null;
                    }
                }

                return this.hsClientTypes;
            }
        }

        public ObservableCollection<HSRole> Roles
        {
            get
            {
                if (this.hsRoles == null)
                {
                    try
                    {
                        this.hsRoles = new ObservableCollection<HSRole>();

                        foreach (SunSeven.DataSource.Role l in lDataContext.Roles)
                        {
                            hsRoles.Add(new HSRole
                            {
                                Id = l.Id,
                                Name = l.Name
                            });
                        }
                    }
                    catch
                    {
                        return null;
                    }
                }

                return this.hsRoles;
            }
        }



        public ObservableCollection<HSVatRate> VATRates
        {
            get
            {
                if (this.hsVATRates == null)
                {
                    try
                    {
                        this.hsVATRates = new ObservableCollection<HSVatRate>();

                        foreach (SunSeven.DataSource.VatRate l in lDataContext.VatRates)
                        {
                            hsVATRates.Add(new HSVatRate 
                            {
                                Id = l.Id,
                                Name = l.Name,
                                Rate = l.Rate 
                            });
                        }
                    }
                    catch
                    {
                        return null;
                    }
                }

                return this.hsVATRates;
            }
        }
    }
}
