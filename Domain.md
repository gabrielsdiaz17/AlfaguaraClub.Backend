# Domain Model — AlfaguaraClub.Backend

All entities extend **AuditableEntity** which provides: `CreatedDate`, `CreatedById`, `UpdatedDate`, `UpdatedById`.

---

## Entities

### Company
Represents the club organization that owns all sites.

| Property | Type | Notes |
|---|---|---|
| CompanyId | long | PK |
| CompanyName | string(100) | |
| CompanyIdentifier | string(20) | Tax/legal ID |
| IdentificationTypeId | int | FK → IdentificationType |
| CompanyLogo | string (longtext) | Base64 or URL |
| IsActive | bool | |

**Relations:** one Company → many Sites

---

### Site
A physical location belonging to the company.

| Property | Type | Notes |
|---|---|---|
| SiteId | long | PK |
| SiteName | string(200) | |
| SiteAddress | string(500) | |
| SiteLocationMap | string? (text) | Embedded map or coordinates |
| CompanyId | long | FK → Company |
| IsActive | bool | |

**Relations:** one Site → many CostCenters

---

### CostCenter
An administrative/financial unit within a site that groups spaces and products.

| Property | Type | Notes |
|---|---|---|
| CostCenterId | long | PK |
| CostCenterCode | string(20) | |
| CostCenterName | string(200) | |
| SiteId | long | FK → Site |
| IsActive | bool | |

**Relations:** one CostCenter → many Spaces; one CostCenter → many Products

---

### Space
A physical space (pool, tennis court, lounge, theater, etc.) that belongs to a cost center and hosts activities.

| Property | Type | Notes |
|---|---|---|
| SpaceId | long | PK |
| SpaceName | string(200) | |
| SpaceDescription | string (text) | |
| CostCenterId | long | FK → CostCenter |
| VideoLink | string? (text) | Optional promo/tour video |
| IsActive | bool | |

**Relations:** one Space → many SpaceActivities; one Space → many Pictures

---

### SpaceActivity
A scheduled activity that takes place in a specific space (class, event, session).

| Property | Type | Notes |
|---|---|---|
| SpaceActivityId | long | PK |
| ActivityName | string(200) | |
| ActivityDescription | string (text) | |
| AvailableQuorum | int | Max participants for this activity |
| TypeActivityId | int? | FK → TypeActivity (nullable) |
| Visibility | ActivityVisibility (enum) | PrivateMembresy = 1, Public = 2 |
| SpaceId | long | FK → Space |
| ActivityDate | DateTimeOffset | |
| StartActivityHour | TimeSpan | |
| EndActivityHour | TimeSpan | |
| IsActive | bool | |

**Relations:** one SpaceActivity → many Bookings; one SpaceActivity → many SpaceActivitySlots; one SpaceActivity → many TennisFieldActivitySlots; one SpaceActivity → many SquashFieldActivitySlots; one SpaceActivity → many Stories

---

### SpaceActivitySlot
A slot within a space activity representing a lane/rail (e.g., swimming lane).

| Property | Type | Notes |
|---|---|---|
| SpaceActivitySlotId | long | PK |
| SpaceActivityId | long | FK → SpaceActivity |
| RailNumber | int | Lane or rail identifier |
| MaxQuorum | int | |
| CurrentQuorum | int | |
| IsAvailable | bool | Computed: CurrentQuorum < MaxQuorum |
| IsActive | bool | |

---

### TennisFieldActivitySlot
A slot within a tennis activity representing a specific field/court.

| Property | Type | Notes |
|---|---|---|
| TennisFieldActivitySlotId | long | PK |
| SpaceActivityId | long | FK → SpaceActivity |
| FieldNumber | int | Court number |
| AvailableSlots | int | |
| IsActive | bool | |

---

### SquashFieldActivitySlot
A slot within a squash activity representing a specific court.

| Property | Type | Notes |
|---|---|---|
| SquashFieldActivitySlotId | long | PK |
| SpaceActivityId | long | FK → SpaceActivity |
| FieldNumber | int | Court number |
| AvailableSlots | int | |
| IsActive | bool | |

---

### TypeActivity
Catalog/lookup for activity types (yoga, swimming, etc.).

| Property | Type | Notes |
|---|---|---|
| TypeActivityId | int | PK |
| TypeActivityName | string(100) | |
| IsActive | bool | |

---

### Role
System roles defining access level.

| Property | Type | Notes |
|---|---|---|
| RoleId | int | PK |
| RoleName | string(200) | e.g. Admin, User |
| IsActive | bool | |

**Defined roles:** Admin (workers), User (Principal, Associated, Guest)

---

### User
Any person registered in the system. Role and TypeUser determine permissions.

| Property | Type | Notes |
|---|---|---|
| UserId | long | PK |
| IdentificationTypeId | int | FK → IdentificationType |
| IdentificationNumber | string(20) | |
| Name | string(200) | |
| LastName | string(200) | |
| Email | string(200) | |
| Password | string (text) | Hashed |
| Address | string (text) | |
| CityAddress | string(200) | |
| PhoneNumber | string(30) | |
| Genre | Genre (enum) | Undefined=0, Male=1, Female=2 |
| RoleId | int | FK → Role |
| MembershipId | long? | FK → Membership (nullable) |
| TypeUser | TypeUser? (enum) | Principal=1, Associated=2, Guest=3 |
| AcceptProtectionData | bool | GDPR / data protection consent |
| Photograph | string? (text) | |
| IsActive | bool | |

**Relations:** one User → many Bookings; one User → many Billings; one User → many Notifications; one User → many BookingQuotas; one User → many CouponPurchases

---

### IdentificationType
Catalog for document/ID types (CC, NIT, passport, etc.).

| Property | Type | Notes |
|---|---|---|
| IdendificationTypeId | int | PK (note: typo in codebase) |
| IdentificationTypeCode | int | |
| Nomenclature | string(20) | e.g. CC, NIT |
| Description | string(500) | |
| IsActive | bool | |

---

### Membership
A membership record that groups associated users and their coupon books.

| Property | Type | Notes |
|---|---|---|
| MembershipId | long | PK |
| UniqueIdentifier | string(50) | Membership number/code |
| IsActive | bool | |

**Relations:** one Membership → many Users; one Membership → many MonthlyCouponBooks

---

### MonthlyCouponBook
Monthly coupon balance assigned to a membership for purchasing products/services.

| Property | Type | Notes |
|---|---|---|
| MonthlyCouponBookId | long | PK |
| MembershipId | long | FK → Membership |
| Month | DateTime | The month this book applies to |
| InitialBalance | decimal | Starting coupon balance |
| CurrentBalance | decimal | Remaining balance |
| IsActive | bool | |

**Relations:** one MonthlyCouponBook → many CouponPurchases

---

### CouponPurchase
A purchase transaction made using coupons from a monthly book.

| Property | Type | Notes |
|---|---|---|
| CouponPurchaseId | long | PK |
| MonthlyCouponBookId | long | FK → MonthlyCouponBook |
| ProductId | long | FK → Product |
| Quantity | int | |
| TotalPrice | decimal | |
| Comment | string?(500) | |
| CostCenterId | long? | FK → CostCenter (nullable) |
| UserId | long? | FK → User (nullable) |

---

### Booking
A reservation by a user for a specific activity (optionally with a slot and membership).

| Property | Type | Notes |
|---|---|---|
| BookingId | long | PK |
| UserId | long | FK → User |
| SpaceActivityId | long | FK → SpaceActivity |
| MembershipId | long? | FK → Membership (nullable) |
| StatusBookingId | int | FK → StatusBooking |
| SpaceActivitySlotId | long? | FK → SpaceActivitySlot (nullable) |
| TennisFieldActivitySlotId | long? | FK → TennisFieldActivitySlot (nullable) |
| SquashFieldActivitySlotId | long? | FK → SquashFieldActivitySlot (nullable) |
| IsActive | bool | |

**Relations:** one Booking → many BookingQuotas; one Booking → one Billing (optional)

---

### BookingQuota
Tracks which users are assigned to a booking (e.g., guest participants added by the principal user).

| Property | Type | Notes |
|---|---|---|
| BookingQuotaId | long | PK |
| BookingId | long | FK → Booking |
| UserId | long | FK → User |
| IsActive | bool | |

---

### StatusBooking
Catalog for booking statuses (Pending, Confirmed, Cancelled, etc.).

| Property | Type | Notes |
|---|---|---|
| StatusBookingId | int | PK |
| Status | string(50) | |
| IsActive | bool | |

---

### Billing
A billing record associated with a user and optionally a booking.

| Property | Type | Notes |
|---|---|---|
| BillingId | long | PK |
| BillingDate | DateTimeOffset | |
| BillingConsecutive | string(50) | Invoice/receipt number |
| UserId | long | FK → User |
| BillingStatusId | int | FK → BillingStatus |
| BookingId | long? | FK → Booking (nullable) |
| PaymentMethodId | int | FK → PaymentMethod |
| Observations | string(500) | |
| IsActive | bool | |

**Relations:** one Billing → many BillingDetails

---

### BillingDetail
Line item within a billing record, linking to a product.

| Property | Type | Notes |
|---|---|---|
| BillingDetailId | long | PK |
| BillingId | long | FK → Billing |
| ProductId | long | FK → Product |
| Quantity | int | |
| SubtotalPrice | decimal | Before tax |
| TotalPrice | decimal | After tax |
| IsActive | bool | |

---

### BillingStatus
Catalog for billing statuses (Pending, Paid, Cancelled, etc.).

| Property | Type | Notes |
|---|---|---|
| BillingStatusId | int | PK |
| Status | string(100) | |
| Nomenclature | string?(20) | Short code |
| IsActive | bool | |

---

### PaymentMethod
Catalog for payment methods (cash, card, MercadoPago, coupons, etc.).

| Property | Type | Notes |
|---|---|---|
| PaymentMethodId | int | PK |
| PaymentMethodCode | string(50) | |
| Description | string(200) | |
| IsActive | bool | |

---

### Product
A product or service that can be purchased (may belong to a cost center and have a tax).

| Property | Type | Notes |
|---|---|---|
| ProductId | long | PK |
| ProductCode | string(20) | |
| ProductName | string(200) | |
| ProductDescription | string(500) | |
| UnitPrice | decimal | |
| TaxId | int? | FK → Tax (nullable) |
| CostCenterId | long? | FK → CostCenter (nullable) |
| IsActive | bool | |
| PublicVisibility | bool | Whether shown publicly |

**Relations:** one Product → many Pictures; one Product → many BillingDetails; one Product → many CouponPurchases

---

### Tax
Tax rates applicable to products.

| Property | Type | Notes |
|---|---|---|
| TaxId | int | PK |
| TaxName | string | |
| TaxValue | int | Integer representation |
| TaxPercentage | double | Actual percentage (e.g. 0.19) |
| IsActive | bool | |

---

### Picture
An image resource attached to a space, story, or product.

| Property | Type | Notes |
|---|---|---|
| PictureId | long | PK |
| PictureName | string(100) | |
| PictureData | string (text) | Base64 or URL |
| PictureType | PictureType (enum) | Space=1, Story=2, Product=3 |
| StoryId | long? | FK → Story (nullable) |
| SpaceId | long? | FK → Space (nullable) |
| ProductId | long? | FK → Product (nullable) |
| IsActive | bool | |

---

### Story
A news/content article or announcement. Can be linked to a space activity.

| Property | Type | Notes |
|---|---|---|
| StoryId | long | PK |
| Title | string(500) | |
| PriorityRating | int | Display order/priority |
| Summary | string(500) | Short excerpt |
| Description | string (text) | Full content |
| CategoryId | int? | FK → Category (nullable) |
| StoryPublishDate | DateTimeOffset | |
| SpaceActivityId | long? | FK → SpaceActivity (nullable) |
| IsActive | bool | |

**Relations:** one Story → many Pictures

---

### Category
Catalog for story/content categories.

| Property | Type | Notes |
|---|---|---|
| CategoryId | int | PK |
| CategoryName | string | |
| IsActive | bool | |

---

### ContactRequest (PQR)
A contact/complaint/request submitted by a user or visitor.

| Property | Type | Notes |
|---|---|---|
| ContactRequestId | long | PK |
| Name | string(100) | Submitter name |
| PhoneNumber | string(20) | |
| Email | string(100) | |
| Message | string (text) | |
| ObservationResponse | string? | Admin response |
| StatusRequest | StatusRequest (enum) | Opened=1, Closed=2 |
| SpaceId | long? | FK → Space (nullable) |
| DateRequest | DateTime | |
| IsActive | bool | |

---

### Notification
System-generated notification sent to a user.

| Property | Type | Notes |
|---|---|---|
| NotificationId | long | PK |
| NotificationTypeId | int | FK → NotificationType |
| UserId | long | FK → User |
| NotificationDate | DateTimeOffset | |
| Subject | string(500) | |
| Message | string (text) | |
| NotificationSent | bool | Whether the notification was dispatched |
| IsActive | bool | |

---

### NotificationType
Catalog for notification types (email, push, SMS, etc.).

| Property | Type | Notes |
|---|---|---|
| NotificationTypeId | int | PK |
| NotificationTypeDescription | string(500) | |
| IsActive | bool | |

---

### Parameter
Dynamic system configuration values (key-value store for runtime constants).

| Property | Type | Notes |
|---|---|---|
| ParameterId | long | PK |
| ParameterName | string(500) | Key |
| ParameterValue | string (text) | Value |
| IsActive | bool | |

---

### UserInfo
Audit log of user login/session data.

| Property | Type | Notes |
|---|---|---|
| UserInfoId | long | PK |
| UserData | string (mediumtext) | Serialized session/device info |
| IdentificationNumber | string | Links to user by ID number |
| RecordDateTime | DateTime | |
| IsActive | bool | |
| IsLoged | bool | Current login state |

---

## Enums

| Enum | Values |
|---|---|
| Genre | Undefined=0, Male=1, Female=2 |
| TypeUser | Principal=1, Associated=2, Guest=3 |
| PictureType | Space=1, Story=2, Product=3 |
| ActivityVisibility | PrivateMembresy=1, Public=2 |
| StatusRequest | Opened=1, Closed=2 |

---

## Aggregate Hierarchy (top-down)

```
Company
└── Site
    └── CostCenter
        ├── Space
        │   ├── Picture
        │   └── SpaceActivity
        │       ├── SpaceActivitySlot
        │       ├── TennisFieldActivitySlot
        │       ├── SquashFieldActivitySlot
        │       └── Story ──► Picture
        └── Product ──► Picture

Membership
├── User (Principal / Associated / Guest)
│   ├── Booking ──► SpaceActivity / Slots
│   │   ├── BookingQuota (guest participants)
│   │   └── Billing
│   │       └── BillingDetail ──► Product
│   └── Notification
└── MonthlyCouponBook
    └── CouponPurchase ──► Product

ContactRequest (PQR) ──► Space (optional)
Parameter (standalone config store)
UserInfo (login audit log)
```
