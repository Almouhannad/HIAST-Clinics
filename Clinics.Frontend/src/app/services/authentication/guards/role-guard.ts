import { Injectable } from '@angular/core';
import { CanActivate, ActivatedRouteSnapshot, RouterStateSnapshot } from '@angular/router';
import { AuthenticationService } from '../authentication.service';
import { Roles } from '../../../classes/Authentication/roles';
import { UserData } from '../../../classes/Authentication/user-data';

@Injectable({
  providedIn: 'root'
})
export class RoleGuard implements CanActivate {

  constructor(private authenticationService: AuthenticationService) { }

  canActivate(route: ActivatedRouteSnapshot, state: RouterStateSnapshot): boolean {
    const userData: UserData | null = this.authenticationService.getUserData();
    const requiredRole: string = route.data['role'];

    if (!requiredRole)
        return true;

    if (requiredRole === Roles.NotRegistered)
        return true;

    if (!userData)
        return false;

    return userData.role === requiredRole;
    
  }

}