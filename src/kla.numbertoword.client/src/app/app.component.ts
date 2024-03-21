import { CommonModule } from '@angular/common';
import { HttpErrorResponse } from '@angular/common/http';
import { Component } from '@angular/core';
import { FormBuilder, FormControl, ReactiveFormsModule, Validators } from '@angular/forms';
import { MatButtonModule } from '@angular/material/button';
import { MatCardModule } from '@angular/material/card';
import { MatFormFieldModule } from '@angular/material/form-field';
import { MatIconModule } from '@angular/material/icon';
import { MatInputModule } from '@angular/material/input';
import { MatSnackBar } from '@angular/material/snack-bar';
import { MatToolbarModule } from '@angular/material/toolbar';
import { RouterOutlet } from '@angular/router';
import { Observable, catchError, of, tap } from 'rxjs';
import { ConversionResponse, WordToNumberService } from './word-to-number.service';

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
    var data = this.frm.controls.userInput.value!.toString();
    this.response$ = this.wordToNumberService.getConvert(data)
      .pipe(
        tap(() => console.log(`sent: ${data}`)),
        catchError(this.handleError.bind(this))
      );
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

    return of();
  }
}

