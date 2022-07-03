import { Component, OnInit } from '@angular/core';
import { UntypedFormBuilder, Validators } from '@angular/forms';
import { ProductDto } from 'src/app/models/product.model';
import { AdminService } from '../admin.service';

@Component({
  selector: 'app-create-product',
  templateUrl: './create-product.component.html',
  styleUrls: ['./create-product.component.css']
})
export class CreateProductComponent implements OnInit {

  constructor(private formBuilder: UntypedFormBuilder, private adminService: AdminService) { }

  form = this.formBuilder.group({
    name: ['', {
      validators: [Validators.required]
    }],
    price: ['', {
      validators: [Validators.required, Validators.min(0), Validators.max(999)]
    }],
    ingredients: ['', {
      validators: [Validators.required, Validators.minLength(10), Validators.maxLength(150)]
    }]
  });

  ngOnInit(): void {
  }

  createProduct(){
    const product = new ProductDto;
    product.name = this.form.controls['name'].value;
    product.price = this.form.controls['price'].value
    product.ingredients = this.form.controls['ingredients'].value

    console.log(product)

    this.adminService.createProduct(product).subscribe( data => {
      console.log(data);
    })

    this.form.reset();
  }
}
