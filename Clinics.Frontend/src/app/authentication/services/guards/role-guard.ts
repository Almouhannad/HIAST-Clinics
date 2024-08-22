import { Injectable } from '@angular/core';
import { CanActivate, ActivatedRouteSnapshot, RouterStateSnapshot, Router } from '@angular/router';
import { AuthenticationService } from '../authentication.service';
import { Roles } from '../../classes/roles';
import { UserData } from '../../classes/user-data';

@Injectable({
  providedIn: 'root'
})
export class RoleGuard implements CanActivate {

  constructor(private authenticationService: AuthenticationService, private router: Router) { }

  canActivate(route: ActivatedRouteSnapshot, state: RouterStateSnapshot): boolean {
    const userData: UserData | null = this.authenticationService.getUserData();
    const requiredRole: string = route.data['role'];

    // No required role
    if (!requiredRole)
        return true;

    // No required role
    if (requiredRole === Roles.NotRegistered)
        return true;

    // Reauired role, but not registered user
    if (!userData)
    {
      this.router.navigate(["errors/forbidden"]);
      return false;
    }

    if (userData.role !== requiredRole)
    {
      this.router.navigate(["errors/forbidden"]);
      return false;
    }
    
    return true;
    
  }

}