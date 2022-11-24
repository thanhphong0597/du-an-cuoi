import Card from "@mui/material/Card";
import CardActionArea from "@mui/material/CardActionArea";
import CardActions from "@mui/material/CardActions";
import CardContent from "@mui/material/CardContent";
import Stack from "@mui/material/Stack";
import Typography from "@mui/material/Typography";
import React from "react";
import { Link } from "react-router-dom";

const Category = ({ category }) => {
    return (
        <Card>
            <CardActionArea>
                <Link to={`/${category.title}/${category.id}`}>
                    <img
                        src={category.image}
                        alt={category.title}
                        className="h-[15rem] object-cover mx-auto"
                        loading="lazy"
                    />
                    <CardContent>
                        <Typography
                            gutterBottom
                            component="div"
                            variant="h5"
                            sx={{
                                whiteSpace: "nowrap",
                                overflow: "hidden",
                                textOverflow: "ellipsis",
                            }}
                        >
                            {category.title}
                        </Typography>
                        <Stack direction="row" justifyContent="space-between">
                            <CardActions disableSpacing>
                                <Typography>₫</Typography>
                                <Typography>{category.price}</Typography>
                            </CardActions>
                            <CardActions>
                                <Typography>đã bán</Typography>
                                <Typography>{category.price}</Typography>
                            </CardActions>
                        </Stack>
                    </CardContent>
                </Link>
            </CardActionArea>
        </Card>
    );
};

export default Category;
