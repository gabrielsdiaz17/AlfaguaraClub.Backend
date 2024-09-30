using AlfaguaraClub.Backend.Application.Services.BillingDetailServices.CreateBillingDetailCommands;
using AlfaguaraClub.Backend.Application.Services.BillingDetailServices.QueryBillingDetailCommands;
using AlfaguaraClub.Backend.Application.Services.BillingDetailServices.UpdateBillingDetailCommands;
using AlfaguaraClub.Backend.Application.Services.BillingServices.CreateBillingCommands;
using AlfaguaraClub.Backend.Application.Services.BillingServices.QueryBillingCommands;
using AlfaguaraClub.Backend.Application.Services.BillingServices.UpdateBillingCommands;
using AlfaguaraClub.Backend.Application.Services.BillingStatusServices.CreateBillingStatusCommands;
using AlfaguaraClub.Backend.Application.Services.BillingStatusServices.QueryBillingStatusCommands;
using AlfaguaraClub.Backend.Application.Services.BillingStatusServices.UpdateBillingStatusCommands;
using AlfaguaraClub.Backend.Application.Services.BookingServices.CreateBookingCommands;
using AlfaguaraClub.Backend.Application.Services.BookingServices.QueryBookingCommands;
using AlfaguaraClub.Backend.Application.Services.BookingServices.UpdateBookingCommands;
using AlfaguaraClub.Backend.Application.Services.CategoryServices.CreateCategoryCommands;
using AlfaguaraClub.Backend.Application.Services.CategoryServices.QueryCategoryCommands;
using AlfaguaraClub.Backend.Application.Services.CategoryServices.UpdateCategoryCommands;
using AlfaguaraClub.Backend.Application.Services.CompanyServices;
using AlfaguaraClub.Backend.Application.Services.CompanyServices.CreateCompanyCommands;
using AlfaguaraClub.Backend.Application.Services.CompanyServices.UpdateCompanyCommands;
using AlfaguaraClub.Backend.Application.Services.ContactRequestServices.CreateContactRequestCommands;
using AlfaguaraClub.Backend.Application.Services.ContactRequestServices.QueryContactRequestCommands;
using AlfaguaraClub.Backend.Application.Services.ContactRequestServices.UpdateContactRequestCommands;
using AlfaguaraClub.Backend.Application.Services.CostcenterServices.CreateCostCenterCommands;
using AlfaguaraClub.Backend.Application.Services.CostcenterServices.QueryCostCenterCommands;
using AlfaguaraClub.Backend.Application.Services.CostcenterServices.UpdateCostCenterCommands;
using AlfaguaraClub.Backend.Application.Services.IdentificationTypeServices.CreateIdentificationTypeCommands;
using AlfaguaraClub.Backend.Application.Services.IdentificationTypeServices.QueryIdentificationTypeCommands;
using AlfaguaraClub.Backend.Application.Services.IdentificationTypeServices.UpdateIdentificationTypeCommands;
using AlfaguaraClub.Backend.Application.Services.MembershipServices.CreateMembershipCommands;
using AlfaguaraClub.Backend.Application.Services.MembershipServices.QueryMembershipCommands;
using AlfaguaraClub.Backend.Application.Services.MembershipServices.UpdateMembershipCommands;
using AlfaguaraClub.Backend.Application.Services.NotificationServices.CreateNotificationCommands;
using AlfaguaraClub.Backend.Application.Services.NotificationServices.QueryNotificationCommands;
using AlfaguaraClub.Backend.Application.Services.NotificationServices.UpdateNotificationCommands;
using AlfaguaraClub.Backend.Application.Services.NotificationTypeServices.CreateNotificationTypeCommands;
using AlfaguaraClub.Backend.Application.Services.NotificationTypeServices.QueryNotificationTypeCommands;
using AlfaguaraClub.Backend.Application.Services.NotificationTypeServices.UpdateNotificationTypeCommands;
using AlfaguaraClub.Backend.Application.Services.ParameterServices.CreateParameterCommands;
using AlfaguaraClub.Backend.Application.Services.ParameterServices.QueryParameterCommands;
using AlfaguaraClub.Backend.Application.Services.ParameterServices.UpdateParameterCommands;
using AlfaguaraClub.Backend.Application.Services.PaymentMethodServices.CreatePaymentMethodCommands;
using AlfaguaraClub.Backend.Application.Services.PaymentMethodServices.QueryPaymentMethodCommands;
using AlfaguaraClub.Backend.Application.Services.PaymentMethodServices.UpdatePaymentMethodCommands;
using AlfaguaraClub.Backend.Application.Services.PictureServices.CreatePictureCommands;
using AlfaguaraClub.Backend.Application.Services.PictureServices.QueryPictureCommands;
using AlfaguaraClub.Backend.Application.Services.PictureServices.UpdatePictureCommands;
using AlfaguaraClub.Backend.Application.Services.ProductServices.CreateProductCommands;
using AlfaguaraClub.Backend.Application.Services.ProductServices.QueryProductCommands;
using AlfaguaraClub.Backend.Application.Services.ProductServices.UpdateProductCommands;
using AlfaguaraClub.Backend.Application.Services.RoleServices.CreateRoleCommands;
using AlfaguaraClub.Backend.Application.Services.RoleServices.QueryRoleCommands;
using AlfaguaraClub.Backend.Application.Services.RoleServices.UpdateRoleCommands;
using AlfaguaraClub.Backend.Application.Services.SiteServices.CreateSiteCommands;
using AlfaguaraClub.Backend.Application.Services.SiteServices.QuerySiteCommands;
using AlfaguaraClub.Backend.Application.Services.SiteServices.UpdateCompanyCommands;
using AlfaguaraClub.Backend.Application.Services.SpaceActivityServices.CreateSpaceActivityCommands;
using AlfaguaraClub.Backend.Application.Services.SpaceActivityServices.QuerySpaceActivityCommands;
using AlfaguaraClub.Backend.Application.Services.SpaceActivityServices.UpdateSpaceActivityCommands;
using AlfaguaraClub.Backend.Application.Services.SpaceServices.CreateSpaceCommands;
using AlfaguaraClub.Backend.Application.Services.SpaceServices.QuerySpaceCommands;
using AlfaguaraClub.Backend.Application.Services.SpaceServices.UpdateSpaceCommands;
using AlfaguaraClub.Backend.Application.Services.StatusBookingServices.CreateStatusBookingCommands;
using AlfaguaraClub.Backend.Application.Services.StatusBookingServices.QueryStatusBookingCommands;
using AlfaguaraClub.Backend.Application.Services.StatusBookingServices.UpdateStatusBookingCommands;
using AlfaguaraClub.Backend.Application.Services.StoryServices.CreateStoryCommands;
using AlfaguaraClub.Backend.Application.Services.StoryServices.QueryStoryCommands;
using AlfaguaraClub.Backend.Application.Services.StoryServices.UpdateStoryCommands;
using AlfaguaraClub.Backend.Application.Services.TaxServices.CreateTaxCommands;
using AlfaguaraClub.Backend.Application.Services.TaxServices.QueryTaxCommands;
using AlfaguaraClub.Backend.Application.Services.TaxServices.UpdateTaxCommands;
using AlfaguaraClub.Backend.Application.Services.TypeActivityServices.CreateTypeActivityCommands;
using AlfaguaraClub.Backend.Application.Services.TypeActivityServices.QueryTypeActivityCommands;
using AlfaguaraClub.Backend.Application.Services.TypeActivityServices.UpdateTypeActivityCommands;
using AlfaguaraClub.Backend.Application.Services.UserInfoServices.CreateUserInfoCommands;
using AlfaguaraClub.Backend.Application.Services.UserInfoServices.QueryUserInfoCommands;
using AlfaguaraClub.Backend.Application.Services.UserInfoServices.UpdateUserInfoCommands;
using AlfaguaraClub.Backend.Application.Services.UserServices.CreateUserCommands;
using AlfaguaraClub.Backend.Application.Services.UserServices.QueryUserCommands;
using AlfaguaraClub.Backend.Application.Services.UserServices.UpdateUserCommands;
using AlfaguaraClub.Backend.Domain.Entities;
using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AlfaguaraClub.Backend.Application.Profiles
{
    public class MappingProfile: Profile
    {
        public MappingProfile() 
        {
            CreateMap<BillingDetail, CreateBillingDetailCommand>().ReverseMap();
            CreateMap<BillingDetail, BillingDetailListVm>().ReverseMap();
            CreateMap<BillingDetail, UpdateBillingDetailCommand>().ReverseMap();
            CreateMap<Product,ProductDto>().ReverseMap();

            CreateMap<Billing,CreateBillingCommand>().ReverseMap();
            CreateMap<Billing, BillingListVm>().ReverseMap();
            CreateMap<Billing, UpdateBillingCommand>().ReverseMap();
            CreateMap<BillingDetail, BillingDetailDto>().ReverseMap();
            CreateMap<BillingStatus,BillingStatusDto>().ReverseMap();
            CreateMap<PaymentMethod,PaymentMethodDto>().ReverseMap();

            CreateMap<BillingStatus, CreateBillingStatusCommand>().ReverseMap();
            CreateMap<BillingStatus, BillingStatusListVm>().ReverseMap();
            CreateMap<BillingStatus, UpdateBillingStatusCommand>().ReverseMap();

            CreateMap<Booking, CreateBookingCommand>().ReverseMap();
            CreateMap<Booking, BookingListVm>().ReverseMap();
            CreateMap<Booking, UpdateBookingCommand>().ReverseMap();
            CreateMap<Billing, BillingDto>().ReverseMap();
            CreateMap<Membership, MembershipDto>().ReverseMap();
            CreateMap<StatusBooking, StatusBookingDto>().ReverseMap();

            CreateMap<Category, CreateCategoryCommand>().ReverseMap();
            CreateMap<Category, CategoryListVm>().ReverseMap();
            CreateMap<Category, UpdateCategoryCommand>().ReverseMap();

            CreateMap<Company,CompanyListVm>().ReverseMap();
            CreateMap<Company,CreateCompanyCommand>().ReverseMap();
            CreateMap<Company,UpdateCompanyCommand>().ReverseMap();

            CreateMap<CostCenter, CreateCostCenterCommand>().ReverseMap();
            CreateMap<CostCenter, CostCenterListVm>().ReverseMap();
            CreateMap<CostCenter, UpdateCostCenterCommand>().ReverseMap();
            CreateMap<Space, SpaceDto>().ReverseMap();

            CreateMap<IdentificationType, CreateIdentificationTypeCommand>().ReverseMap();
            CreateMap<IdentificationType, IdentificationTypeListVm>().ReverseMap();
            CreateMap<IdentificationType, UpdateIdentificationTypeCommand>().ReverseMap();

            CreateMap<Membership, CreateMembershipCommand>().ReverseMap();
            CreateMap<Membership, MembershipListVm>().ReverseMap();
            CreateMap<Membership, UpdateMembershipCommand>().ReverseMap();
            CreateMap<User, UserDto>().ReverseMap();

            CreateMap<Notification, CreateNotificationCommand>().ReverseMap();
            CreateMap<Notification, NotificationListVm>().ReverseMap();
            CreateMap<Notification, UpdateNotificationCommand>().ReverseMap();
            CreateMap<NotificationType, NotificationTypeDto>().ReverseMap();

            CreateMap<NotificationType,CreateNotificationTypeCommand>().ReverseMap();
            CreateMap<NotificationType, UpdateNotificationTypeCommand>().ReverseMap();
            CreateMap<NotificationType, NotificationTypeListVm>().ReverseMap();


            CreateMap<Parameter, CreateParameterCommand>().ReverseMap();
            CreateMap<Parameter, ParameterListVm>().ReverseMap();
            CreateMap<Parameter, UpdateParameterCommand>().ReverseMap();

            CreateMap<PaymentMethod, CreatePaymentMethodCommand>().ReverseMap();
            CreateMap<PaymentMethod, PaymentMethodListVm>().ReverseMap();
            CreateMap<PaymentMethod, UpdatePaymentMethodCommand>().ReverseMap();

            CreateMap<Picture, CreatePictureCommand>().ReverseMap();
            CreateMap<Picture, PictureListVm>().ReverseMap();
            CreateMap<Picture, UpdatePictureCommand>().ReverseMap();

            CreateMap<Product, CreateProductCommand>().ReverseMap();
            CreateMap<Product, ProductListVm>().ReverseMap();
            CreateMap<Product, UpdateProductCommand>().ReverseMap();
            CreateMap<Tax, TaxDto>().ReverseMap();

            CreateMap<Role, CreateRoleCommand>().ReverseMap();
            CreateMap<Role, RoleListVm>().ReverseMap();
            CreateMap<Role, UpdateRoleCommand>().ReverseMap();

            CreateMap<Site,SiteListVm>().ReverseMap();
            CreateMap<Site,CreateSiteCommand>().ReverseMap();
            CreateMap<Site,UpdateSiteCommand>().ReverseMap();
            CreateMap<CostCenter, CostCenterDto>().ReverseMap();

            CreateMap<Space,CreateSpaceCommand>().ReverseMap();
            CreateMap<Space,UpdateSpaceCommand>().ReverseMap();
            CreateMap<Space,SpaceListVm>().ReverseMap();
            CreateMap<Picture,PictureDto>().ReverseMap();
            CreateMap<SpaceActivity,SpaceActivityDto>().ReverseMap();

            CreateMap<SpaceActivity,CreateSpaceActivityCommand>().ReverseMap();
            CreateMap<SpaceActivity,UpdateSpaceActivityCommand>().ReverseMap();
            CreateMap<SpaceActivity,SpaceActivityListVm>().ReverseMap();
            CreateMap<Booking,BookingDto>().ReverseMap();

            CreateMap<StatusBooking, CreateStatusBookingCommand>().ReverseMap();
            CreateMap<StatusBooking, UpdateStatusBookingCommand>().ReverseMap();
            CreateMap<StatusBooking, StatusBookingListVm>().ReverseMap();

            CreateMap<Story, CreateStoryCommand>().ReverseMap();
            CreateMap<Story, StoryListVm>().ReverseMap();
            CreateMap<Story, UpdateStoryCommand>().ReverseMap();
            CreateMap<Story, StoryDto>().ReverseMap();
            CreateMap<Category, CategoryDto>().ReverseMap();

            CreateMap<Tax, CreateTaxCommand>().ReverseMap();
            CreateMap<Tax, TaxListVm>().ReverseMap();
            CreateMap<Tax, UpdateTaxCommand>().ReverseMap();

            CreateMap<TypeActivity, CreateTypeActivityCommand>().ReverseMap();
            CreateMap<TypeActivity, TypeActivityListVm>().ReverseMap();
            CreateMap<TypeActivity, UpdateTypeActivityCommand>().ReverseMap();
            CreateMap<TypeActivity, TypeActivityDto>().ReverseMap();


            CreateMap<User, UserListVm>().ReverseMap();
            CreateMap<User, CreateUserCommand>().ReverseMap();
            CreateMap<User, UpdateUserCommand>().ReverseMap();
            CreateMap<User, UpdateUserPasswordCommand>().ReverseMap();
            CreateMap<IdentificationType, IdentificationTypeDto>().ReverseMap();
            CreateMap<Role, RoleDto>().ReverseMap();

            CreateMap<ContactRequest,ContactRequestListVm>().ReverseMap();
            CreateMap<ContactRequest,CreateContactRequestCommand>().ReverseMap();
            CreateMap<ContactRequest,UpdateContactRequestCommand>().ReverseMap();

            CreateMap<UserInfo, CreateUserInfoCommand>().ReverseMap();
            CreateMap<UserInfo, UpdateUserInfoCommand>().ReverseMap();
            CreateMap<UserInfo, UserInfoVm>().ReverseMap();

        }
    }
}
