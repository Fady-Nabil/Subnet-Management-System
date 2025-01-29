import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { AuthComponent } from '../components/auth/auth.component';
import { SubnetListComponent } from '../components/subnet-list/subnet-list.component';
import { IpListComponent } from '../components/ip-list/ip-list.component';
import { FileUploadComponent } from '../components/file-upload/file-upload.component';

const routes: Routes = [
  { path: '', component: AuthComponent },
  { path: 'upload', component: FileUploadComponent },
  { path: 'subnets', component: SubnetListComponent },
  { path: 'subnets/:subnetId/ips', component: IpListComponent },

];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }
