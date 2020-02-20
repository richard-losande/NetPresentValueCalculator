import React,{Component} from "react";
import CssBaseline from '@material-ui/core/CssBaseline';
import Container from '@material-ui/core/Container';
import TextField from '@material-ui/core/TextField';
import Button from '@material-ui/core/Button';
import { withStyles } from '@material-ui/core/styles';
import axios from 'axios';

const styles = theme => ({
    container: {
        display: 'flex',
        flexWrap: 'wrap',
        backgroundColor: 'white'
    },
    textField: {
        marginLeft: theme.spacing(1),
        marginRight: theme.spacing(1),
        
      },
      dense: {
        marginTop: 16,  
      },
      menu: {
        width: 200,
      },
      button: {
        margin: theme.spacing(1),

      },
      input: {
        display: 'none',
      },
      marginRight :{
          marginRight : 20,
      }
})


    class CashFlow extends Component {
        constructor(props) {
            super(props);
            this.state = { 
                cashflows: [] ,
                initialinvestment : 0,
                discountrate: 0,
                upperbound:0,
                lowerbound:0,
                incrementalrate : 2,
                discountratetype : "Fixed"
            };


        }

        handleSumit = event =>{

            event.preventDefault();
            const netrepresetvaluedata = {
                InitialInvestment : this.state.initialinvestment,
                DiscountRate : this.state.discountrate,
                UpperBound : this.state.upperbound,
                LowerBound : this.state.lowerbound,
                IncrementalRate : this.state.incrementalrate,
                discountratetype : this.state.discountratetype,
                cashflows : this.state.cashflows
            }
            console.log(netrepresetvaluedata);
            axios.post(`/api/NetPresentValue/Compute`, netrepresetvaluedata)
      .then(res => {
        console.log(res);
        console.log(res.data);
      })

    }
        appendInput() {
            var newInput = { id:this.state.cashflows.length == 0 ? 1: this.state.cashflows.length + 1, cashflowamount: 0 }
            this.setState({
                ...this.state,
               cashflows: [...this.state.cashflows, newInput]
            })
        }
        handleChange = (event,key) => {
            const arr = this.state.cashflows;
            const cashflows = arr.map((input, index) => {
                if (key === index)
                    input.cashflowamount = event.target.value;
                
                return input;
            });
            this.setState({ cashflows });
        }

        handleChangeInitialInvestment = (event) => {
            this.setState({ initialinvestment: event.target.value });
          }
          handleChangeDiscountRate = (event) => {
            this.setState({ discountrate: event.target.value });
          }

        render() {
            return(
                <React.Fragment>
                <CssBaseline />
                <Container maxWidth="sm">
                  <form className={this.props.classes.container} noValidate autoComplete="off" onSubmit= {this.handleSumit}>
                <TextField 
                label="Initial Investment"
                id="outlined-basic" 
                variant="outlined"
                value={this.state.initialinvestment}
                 onChange={this.handleChangeInitialInvestment.bind(this)} 
                 fullWidth/>               
                <TextField 
                label="Discount Rate"
                id="outlined-basic" 
                variant="outlined"
                value={this.state.discountrate}
                 onChange={this.handleChangeDiscountRate.bind(this)}
                  fullWidth/>
                 {this.state.cashflows.map((input,key) =>
                    <TextField
                    label="Cash Flow"
                    id={input.value}
                    key={key}
                    value={input.cashflowamount}
                    className={this.props.classes.textField}
                    onChange={event => this.handleChange(event, key)}
                    variant="outlined"
                    fullWidth
                   />)} 
                <Button className ={this.props.classes.marginRight} onClick={ () => this.appendInput() } variant="contained" color="primary" align="right" >
                  Add CashFlow
                </Button>
          
                <Button variant="contained" color="secondary" align="right" type="submit">
                  Calculate
                </Button>               
                </form>
                <br>
                </br>
                </Container>
              </React.Fragment>
            );
        }

    }
    export default withStyles(styles)(CashFlow);
