import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { HomeComponent } from './components/shared/home/home.component';
import { RoleGuard } from './services/authentication/guards/role-guard';
import { Roles } from './classes/authentication/roles';
import { ForbiddenComponent } from './components/shared/errors/forbidden/forbidden.component';
import { NotFoundComponent } from './components/shared/errors/not-found/not-found.component';
import { TestSignalRComponent } from './components/notifications/test-signal-r/test-signal-r.component';
import { DoctorUsersComponent } from './components/admin/doctor-users/doctor-users.component';
import { AdminDashboardComponent } from './components/admin/admin-dashboard/admin-dashboard.component';
import { CreateDoctorUserFormComponent } from './components/admin/create-doctor-user-form/create-doctor-user-form.component';
import { UpdateDoctorUserComponent } from './components/admin/update-doctor-user/update-doctor-user.component';
import { ReceptionistUserComponent } from './components/admin/receptionist-user/receptionist-user.component';
import { ReceptionistUsersComponent } from './components/admin/receptionist-users/receptionist-users.component';
import { ReceptionistDashboardComponent } from './components/receptionist/receptionist-dashboard/receptionist-dashboard.component';
import { WaitingListComponent } from './components/receptionist/waiting-list/waiting-list.component';

const routes: Routes = [
  {
    path: '',
    redirectTo: 'home',
    pathMatch: 'full',
  },

  {
    path: 'home',
    component: HomeComponent,
    canActivate: [RoleGuard],
    data: { role: Roles.NotRegistered }
  },
  
  {
    path: 'errors/forbidden',
    component: ForbiddenComponent,
    canActivate: [RoleGuard],
    data: { role: Roles.NotRegistered }
  },

  {
    path: 'admin',
    component: AdminDashboardComponent,
    canActivate: [RoleGuard],
    canActivateChild: [RoleGuard],
    
    data: { role: Roles.Admin },
    children: [
      {
        path: '',
        redirectTo: '/home',
        pathMatch: 'full'
      },
      {
        path: 'doctors',
        component: DoctorUsersComponent
      },
      {
        path: 'doctors/create',
        component: CreateDoctorUserFormComponent
      },
      {
        path: 'doctors/update/:id',
        component: UpdateDoctorUserComponent
      },
      {
        path: 'receptionists',
        component: ReceptionistUsersComponent
      }
    ]
  },

  {
    path: 'receptionist',
    component: ReceptionistDashboardComponent,
    canActivate: [RoleGuard],
    canActivateChild: [RoleGuard],
    
    data: { role: Roles.Receptionist },
    children: [
      {
        path: '',
        redirectTo: '/home',
        pathMatch: 'full'
      },
      {
        path: 'waitinglist',
        component: WaitingListComponent
      }
    ]
  },
  
  // #region Testing SignalR
  {
    path: 'testing',
    component: TestSignalRComponent,
    canActivate: [RoleGuard],
    data: { role: Roles.NotRegistered }
  },
  // #endregion
  
  // Everything else
  {
    path: '**',
    component: NotFoundComponent
  }
];
@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }
