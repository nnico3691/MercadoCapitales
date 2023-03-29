import { Button, Grid, Paper, Typography } from "@mui/material";
import React from "react";
import Deposits from "./Deposits";
import { styled } from "@mui/material/styles";
import ButtonBase from "@mui/material/ButtonBase";
import InputIcon from "@mui/icons-material/Input";
import { Block } from "@mui/icons-material";
import PaidIcon from "@mui/icons-material/Paid";
import ShoppingCartIcon from "@mui/icons-material/ShoppingCart";

const ImageButton = styled(ButtonBase)(({ theme }) => ({
  position: "relative",
  height: 140,
  display: "inline",
  [theme.breakpoints.down("sm")]: {
    width: "100% !important", // Overrides inline-style
    height: 100,
  },
  "&:hover, &.Mui-focusVisible": {
    zIndex: 1,
    backgroundColor: "#1976d2",
    borderColor: "#0062cc",
    boxShadow: "none",
    "& .MuiImageBackdrop-root": {
      opacity: 0.15,
    },
    "& .MuiImageMarked-root": {
      opacity: 0,
    },
  },
}));

const ButtonMenu = () => {
  return (
    <>
      <Grid item xs={12} md={4} lg={3}>
        <Paper
          sx={{
            p: 0,
            display: "flex",
            flexDirection: "column",
            height: 140,
          }}
        >
          <ImageButton>
            <Grid
              item
              xs={12}
              md={12}
              lg={12}
              sx={{
                p: 2,
              }}
            >
              <Typography>Depositar</Typography>
            </Grid>
            <Grid item xs={12} md={12} lg={12}>
              <InputIcon fontSize="large"></InputIcon>
            </Grid>
          </ImageButton>
        </Paper>
      </Grid>
      {/* Recent Deposits */}
      <Grid item xs={12} md={4} lg={3}>
        <Paper
          sx={{
            p: 0,
            display: "flex",
            flexDirection: "column",
            height: 140,
          }}
        >
          <ImageButton>
            <Grid
              item
              xs={12}
              md={12}
              lg={12}
              sx={{
                p: 2,
              }}
            >
              <Typography>Dolar MEP</Typography>
            </Grid>
            <Grid item xs={12} md={12} lg={12}>
              <PaidIcon fontSize="large"></PaidIcon>
            </Grid>
          </ImageButton>
        </Paper>
      </Grid>
      <Grid item xs={12} md={4} lg={3}>
        <Paper
          sx={{
            p: 0,
            display: "flex",
            flexDirection: "column",
            height: 140,
          }}
        >
          <ImageButton>
            <Grid
              item
              xs={12}
              md={12}
              lg={12}
              sx={{
                p: 2,
              }}
            >
              <Typography>Compra Rapida</Typography>
            </Grid>
            <Grid item xs={12} md={12} lg={12}>
              <ShoppingCartIcon fontSize="large"></ShoppingCartIcon>
            </Grid>
          </ImageButton>
        </Paper>
      </Grid>
      <Grid item xs={12} md={4} lg={3}>
        <Paper
          sx={{
            p: 2,
            display: "flex",
            flexDirection: "column",
            height: 140,
          }}
        >
          <Deposits />
        </Paper>
      </Grid>
    </>
  );
};

export default ButtonMenu;
