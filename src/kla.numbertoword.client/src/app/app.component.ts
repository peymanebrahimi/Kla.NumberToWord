import { CommonModule } from '@angular/common';
import { Component } from '@angular/core';
import { FormBuilder, FormControl, ReactiveFormsModule, Validators } from '@angular/forms';
import { MatButtonModule } from '@angular/material/button';
import { MatCardModule } from '@angular/material/card';
import { MatFormFieldModule } from '@angular/material/form-field';
import { MatIconModule } from '@angular/material/icon';
import { MatInputModule } from '@angular/material/input';
import { MatToolbarModule } from '@angular/material/toolbar';
import { RouterOutlet } from '@angular/router';
import { Observable, catchError, config, of, tap, throwError } from 'rxjs';
import { ConversionResponse, WordToNumberService } from './word-to-number.service';
import { MatSnackBar } from '@angular/material/snack-bar';

import { HttpErrorResponse } from '@angular/common/http';

@Component({
  selector: 'app-root',
  standalone: true,
  imports: [RouterOutlet,
    CommonModule,
    ReactiveFormsModule,
    MatCardModule,
    MatToolbarModule,
    MatButtonModule,
    MatIconModule,
    MatFormFieldModule,
    MatInputModule,
  ],
  templateUrl: './app.component.html',
  styleUrl: './app.component.css'
})
export class AppComponent {
  title = 'K L A';
  response$?: Observable<null | ConversionResponse>;

  constructor(private formBuilder: FormBuilder,
    private wordToNumberService: WordToNumberService,
    private snackBar: MatSnackBar) { }

  frm = this.formBuilder.group({
    userInput: new FormControl('99 999,09', [
      Validators.required,
      Validators.minLength(1),
      // Validators.pattern('^[0-9 ,]*$')
    ]),
  })

  convertToWord() {
    var x =this.frm.controls.userInput.value!.toString();
    this.response$ = this.wordToNumberService.getConvert(this.frm.controls.userInput.value!.toString())
      .pipe(
        tap(()=>console.log(`sent: ${x}`)),
        catchError(this.handleError.bind(this))
      );
    //console.info(this.frm.controls.userInput.value);
  }

  // this should not be here, but the task is for c# developer ;)
  private handleError(error: HttpErrorResponse) {
    if (error.status === 0) {
      console.error('An error occurred:', error.error);
    } else {
      this.snackBar.open(error.error, 'close', {
        horizontalPosition: 'end',
        verticalPosition: 'top',
        duration: 5000
      });
    }
    // Return an observable with a user-facing error message.
    return of();// throwError(() => new Error('Something bad happened; please try again later.'));
  }
}

