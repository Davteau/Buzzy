#  📌 Endpoints for appointments 

---

## Basic CRUD

### POST
### DELETE
### GET BY USERID (APPOINTMENT HISTORY)
### GET BY APPOINTMENTID (DETAILS FOR USER)
### GET BY BUSINESSID (LIST FOR BUSINESS CALENDAR)

### PUT CONFIRM
### PUT CANCEL
### PUT COMPLETE
### PUT RESCHEDULE

# Appointment entity
 - [ ] Guid Id
 - [ ] Guid ClientId
 - [ ] Guid BusinessId
 - [ ] Guid ServiceId
 - [ ] DateTime Start
 - [ ] DateTime End 
 - [ ] Enum Status
 - [ ] int Price
 - [ ] DateTime CreatedAt
 - [ ] DateTime UpdatedAt

 # Business entity
 - [ ] Guid Id
 - [ ] Guid OwnerId
 - [ ] String Name
 - [ ] Enum Category